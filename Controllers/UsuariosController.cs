using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using TCCEcoCria.Data;
using TCCEcoCria.Utils;
using TCCEcoCria.Services;
using TCCEcoCria.DTOs;

namespace RpgApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService; // Injeção do serviço de envio de e-mails

        public UsuariosController(DataContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        // Enviar email (corrigido)
        [HttpPost("EnviarEmail")]
        public IActionResult EnviarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("E-mail não pode ser vazio.");
            }

            string subject = "Código de Recuperação";
            string body = "<h1>Código para verificação de troca de senha</h1><p>Copie e cole o código</p>";

            // Envia o e-mail com o serviço injetado
            _emailService.EnviarEmailAsync(email, subject, body);

            return Ok("E-mail enviado com sucesso!");
        }

        // Método para criar token JWT
        private string CriarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                new Claim(ClaimTypes.Role, usuario.Perfil)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Método que verifica se o usuário já existe
        private async Task<bool> UsuarioExistente(string username)
        {
            return await _context.TB_USUARIOS.AnyAsync(x => x.NomeUsuario.ToLower() == username.ToLower());
        }

        // Registrar novo usuário
        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.NomeUsuario))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordUsuario, out byte[] hash, out byte[] salt);
                user.PasswordUsuario = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.IdUsuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Autenticar usuário e gerar token
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.NomeUsuario.ToLower().Equals(credenciais.NomeUsuario.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordUsuario, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    usuario.DataAcesso = DateTime.Now;
                    _context.TB_USUARIOS.Update(usuario);
                    await _context.SaveChangesAsync();

                    usuario.PasswordHash = null;
                    usuario.PasswordSalt = null;
                    usuario.Token = CriarToken(usuario);
                    
                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Enviar código de recuperação de senha para o email do usuário
        [AllowAnonymous]
        [HttpPost("EsqueciSenha")]
        public async Task<IActionResult> EsqueciSenha([FromBody] RecuperacaoSenhaDto dados)
        {
            var usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(u => u.EmailUsuario == dados.Email);

            if (usuario == null)
                return BadRequest("Email não encontrado.");

            var codigo = new Random().Next(100000, 999999).ToString(); // Gera código de 6 dígitos.
            usuario.CodigoRecuperacao = codigo;
            usuario.DataCodigoExpiracao = DateTime.UtcNow.AddMinutes(15); // Expira em 15 minutos.

            // Enviar email de recuperação com o código gerado
            await _emailService.EnviarEmailAsync(usuario.EmailUsuario, "Código de Recuperação", $"Seu código é {codigo}");

            await _context.SaveChangesAsync();
            return Ok("Código enviado.");
        }

        // Validar o código de recuperação
        [AllowAnonymous]
        [HttpPost("ValidarCodigo")]
        public IActionResult ValidarCodigo([FromBody] RecuperacaoSenhaDto dados)
        {
            var usuario = _context.TB_USUARIOS.FirstOrDefault(u => u.EmailUsuario == dados.Email && u.CodigoRecuperacao == dados.Codigo);

            if (usuario == null || usuario.DataCodigoExpiracao < DateTime.UtcNow)
                return BadRequest("Código inválido ou expirado.");

            // Se o código for válido, retornar sucesso
            return Ok("Código válido.");
        }

        // Alterar a senha do usuário
        [AllowAnonymous]
        [HttpPost("MudandoSenha")]
        public async Task<IActionResult> MudandoSenha([FromBody] MudancaSenhaDto dados)
        {
            // Validação da nova senha
            if (dados.NovaSenha != dados.ConfirmarSenha)
            {
                return BadRequest("As senhas não coincidem.");
            }

            // Lógica para atualizar a senha do usuário
            var usuario = await _context.TB_USUARIOS
                .FirstOrDefaultAsync(u => u.CodigoRecuperacao == dados.NovaSenha); // Exemplo de lógica para encontrar o usuário

            if (usuario == null)
            {
                return BadRequest("Código de recuperação inválido.");
            }

            Criptografia.CriarPasswordHash(dados.NovaSenha, out byte[] hash, out byte[] salt);
            usuario.PasswordHash = hash;
            usuario.PasswordSalt = salt;
            usuario.CodigoRecuperacao = null; // Limpar o código de recuperação após o uso.

            await _context.SaveChangesAsync();

            return Ok("Senha alterada com sucesso.");
        }

        // Obter todos os usuários
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                List<Usuario> lista = await _context.TB_USUARIOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Obter um usuário por ID
        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.IdUsuario == usuarioId);

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Alterar e-mail do usuário
        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.IdUsuario == u.IdUsuario);

                usuario.EmailUsuario = u.EmailUsuario;

                var attach = _context.Attach(usuario);
                attach.Property(x => x.IdUsuario).IsModified = false;
                attach.Property(x => x.EmailUsuario).IsModified = true;

                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

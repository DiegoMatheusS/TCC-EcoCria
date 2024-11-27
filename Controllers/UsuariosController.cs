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
using TCCEcoCria.Data;
using TCCEcoCria.Services;
using TCCEcoCria.DTOs;
using TCCEcoCria.Utils;
using Models;

namespace TCCEcoCria.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public UsuariosController(DataContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

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

        private async Task<bool> UsuarioExistente(string username)
        {
            return await _context.TB_USUARIOS.AnyAsync(x => x.EmailUsuario.ToLower() == username.ToLower());
        }

        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.EmailUsuario))
                    throw new Exception("Email de usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordUsuario, out byte[] hash, out byte[] salt);
                user.PasswordUsuario = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.IdUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                   .FirstOrDefaultAsync(x => x.EmailUsuario.ToLower() == credenciais.EmailUsuario.ToLower());

                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                if (!Criptografia.VerificarPasswordHash(credenciais.PasswordUsuario, usuario.PasswordHash, usuario.PasswordSalt))
                    throw new Exception("Senha incorreta.");

                usuario.DataAcesso = DateTime.Now;
                _context.TB_USUARIOS.Update(usuario);
                await _context.SaveChangesAsync();

                usuario.PasswordHash = null;
                usuario.PasswordSalt = null;
                usuario.Token = CriarToken(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   [AllowAnonymous]
[HttpPost("EsqueciSenha")]
public async Task<IActionResult> EnviarCodigoEsqueciSenha(string email)
{
    try
    {
        var usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(u => u.EmailUsuario == email);

        if (usuario == null)
        {
            return BadRequest("E-mail não encontrado."); // Certifique-se de que a resposta é BadRequest
        }

        // Geração do código de recuperação e envio de e-mail
        string codigo = GerarCodigoSeguranca();
        usuario.CodigoRecuperacao = codigo;
        usuario.DataCodigoExpiracao = DateTime.Now.AddHours(1); // O código expira em 1 hora
        _context.TB_USUARIOS.Update(usuario);
        await _context.SaveChangesAsync();

        // Enviar código para o e-mail do usuário
        await _emailService.EnviarEmailAsync(usuario.EmailUsuario, "Código de Recuperação", $"Seu código de recuperação é: {codigo}");

        return Ok("Código enviado para o seu e-mail.");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message); // Captura outros erros e retorna como BadRequest
    }
}

       [AllowAnonymous]
[HttpPost("MudandoSenha")]
public async Task<IActionResult> MudandoSenha(string codigo, string novaSenha, string confirmarSenha)
{
    try
    {
        if (novaSenha != confirmarSenha)
            return BadRequest("As senhas não coincidem.");

        // Validar o código de segurança
        var usuario = await _context.TB_USUARIOS
         .FirstOrDefaultAsync(u => u.CodigoRecuperacao == codigo && u.DataCodigoExpiracao.HasValue && u.DataCodigoExpiracao > DateTime.Now);

        if (usuario == null)
            return BadRequest("Código inválido ou expirado."); // Aqui retornamos o erro se o código for inválido ou expirado.

        // Criptografar a nova senha
        Criptografia.CriarPasswordHash(novaSenha, out byte[] hash, out byte[] salt);
        usuario.PasswordHash = hash;
        usuario.PasswordSalt = salt;
        usuario.DataCodigoExpiracao = null; // Limpar o código após a alteração de senha

        _context.TB_USUARIOS.Update(usuario);
        await _context.SaveChangesAsync();

        return Ok("Senha alterada com sucesso.");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}

        private string GerarCodigoSeguranca()
        {
            // Gerar um código aleatório ou usar uma biblioteca de geração de códigos
            return Guid.NewGuid().ToString("N").Substring(0, 6); // Exemplo de código de 6 dígitos
        }
        [AllowAnonymous]
[HttpPost("ValidarCodigo")]
public async Task<IActionResult> ValidarCodigo([FromBody] ValidacaoCodigoRequest request)
{
    try
    {
        // Verificar se o usuário existe
        var usuario = await _context.TB_USUARIOS
            .FirstOrDefaultAsync(u => u.EmailUsuario == request.Email);

        if (usuario == null)
        {
            return BadRequest("Usuário não encontrado.");
        }

        // Verificar se o código corresponde e se ainda não expirou
        if (usuario.CodigoRecuperacao != request.Codigo || usuario.DataCodigoExpiracao == null || usuario.DataCodigoExpiracao <= DateTime.Now)
        {
            return BadRequest("Código inválido ou expirado.");
        }

        return Ok("Código validado com sucesso.");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                List<Usuario> lista = await _context.TB_USUARIOS.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS
                   .FirstOrDefaultAsync(x => x.IdUsuario == usuarioId);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS
                   .FirstOrDefaultAsync(x => x.NomeUsuario.ToLower() == login.ToLower());

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Método para alteração do e-mail
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

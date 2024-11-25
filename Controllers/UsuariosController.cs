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
using TCCEcoCria.Models;
using TCCEcoCria.Utils;

namespace RpgApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UsuariosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            if (await _context.TB_USUARIOS.AnyAsync(x => x.NomeUsuario.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

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
        

       [AllowAnonymous]
[HttpGet("EsqueciSenha")]
public IActionResult EsqueciSenha()
{
    return View();
}

[AllowAnonymous]
[HttpPost("EsqueciSenha")]
public async Task<IActionResult> EnviarCodigoEsqueciSenha(string email)
{
    var usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(u => u.EmailUsuario == email);

    if (usuario == null)
    {
        return BadRequest("E-mail não encontrado.");
    }

    // Gerar código de verificação (isso deve ser um código único e temporário)
    string codigo = GerarCodigoSeguranca(); 

    // Enviar o código para o e-mail do usuário (implementar a lógica de envio de e-mail)
    await _emailService.EnviarEmail(usuario.EmailUsuario, "Código de Recuperação", $"Seu código de recuperação é: {codigo}");

    return RedirectToAction("MudandoSenha");
}

[AllowAnonymous]
[HttpGet("MudandoSenha")]
public IActionResult MudandoSenha()
{
    return View();
}

[AllowAnonymous]
[HttpPost("MudandoSenha")]
public async Task<IActionResult> MudandoSenha(string codigo, string novaSenha, string confirmarSenha)
{
    if (novaSenha != confirmarSenha)
    {
        return BadRequest("As senhas não coincidem.");
    }

    // Validar o código de segurança (você precisaria verificar se o código é válido)
    var usuario = await ValidarCodigoDeSeguranca(codigo);
    if (usuario == null)
    {
        return BadRequest("Código inválido ou expirado.");
    }

    // Atualizar a senha do usuário
    Criptografia.CriarPasswordHash(novaSenha, out byte[] hash, out byte[] salt);
    usuario.PasswordHash = hash;
    usuario.PasswordSalt = salt;
    await _context.SaveChangesAsync();

    return RedirectToAction("Login", "Usuarios");
}

private string GerarCodigoSeguranca()
{
    // Gerar um código aleatório ou usar uma biblioteca de geração de códigos
    return Guid.NewGuid().ToString("N").Substring(0, 6); // Exemplo de código de 6 dígitos
}

private async Task<Usuario> ValidarCodigoDeSeguranca(string codigo)
{
    // Lógica para validar o código, por exemplo, buscar em uma tabela de códigos temporários
    return await _context.TB_USUARIOS.FirstOrDefaultAsync(u => u.CodigoRecuperacao == codigo);
}

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

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.TB_USUARIOS //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.IdUsuario == usuarioId);

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.TB_USUARIOS //Busca o usuário no banco através do login
                   .FirstOrDefaultAsync(x => x.NomeUsuario.ToLower() == login.ToLower());

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Método para alteração do e-mail
        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.IdUsuario == u.IdUsuario);

                usuario.EmailUsuario = u.EmailUsuario;                

                var attach = _context.Attach(usuario);
                attach.Property(x => x.IdUsuario).IsModified = false;
                attach.Property(x => x.EmailUsuario).IsModified = true;                

                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

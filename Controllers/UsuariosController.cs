using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCEcoCria.Data;
using TCCEcoCria.Models.Enuns;
using TCCEcoCria.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using TCCEcoCria.Utils;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;



namespace TCCEcoCria.Controllers
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
                new Claim(ClaimTypes.Name, usuario.NomeUsuario)
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
        
       private async Task<bool> UsuarioExistente(string EmailUsuario)
        {
            if (await _context.TB_USUARIOS.AnyAsync(x => x.EmailUsuario.ToLower() == EmailUsuario.ToLower()))
            {
                return true;
            }
            return false;
        }

        [AllowAnonymous] //permitir anonymous
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistraUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.EmailUsuario))
                    throw new System.Exception("Email de usuário já existe");

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
        public async Task<IActionResult> AtutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.EmailUsuario.ToLower().Equals(credenciais.EmailUsuario.ToLower()));
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");

                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordUsuario, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha Incorreta.");
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuario removerU = await _context.TB_USUARIOS.FirstOrDefaultAsync(r => r.IdUsuario == id);
                _context.TB_USUARIOS.Remove(removerU);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 


        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.IdUsuario == usuarioId);

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

        //Método para alteração da geolocalização
        [HttpPut("AtualizarLocalizacao")]
        public async Task<IActionResult> AtualizarLocalizacao(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIOS //Busca o usuário no banco através do Id
                .FirstOrDefaultAsync(x => x.IdUsuario == u.IdUsuario);
                usuario.Latitude = u.Latitude;
                usuario.Longitude = u.Longitude;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.IdUsuario).IsModified = false;
                attach.Property(x => x.Latitude).IsModified = true;
                attach.Property(x => x.Longitude).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
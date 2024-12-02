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
using TCCEcoCria.DTOs;
using TCCEcoCria.Services;
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

        #region Autenticação e Registro
              private string CriarToken(Usuario usuario)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                new Claim(ClaimTypes.Role, usuario.Perfil)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["ConfiguracaoToken:Chave"]));

            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<bool> UsuarioExistente(string email)
        {
            return await _context.TB_USUARIOS.AnyAsync(x => x.EmailUsuario.ToLower() == email.ToLower());
        }
        
      [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario user)
        {
            if (await UsuarioExistente(user.EmailUsuario))
                return BadRequest("E-mail já cadastrado.");

            Criptografia.CriarPasswordHash(user.PasswordUsuario, out byte[] hash, out byte[] salt);
            user.PasswordUsuario = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            await _context.TB_USUARIOS.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user.IdUsuario);
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario([FromBody] Usuario credenciais)
        {
            Usuario? usuario = await _context.TB_USUARIOS
                .FirstOrDefaultAsync(x => x.EmailUsuario.ToLower() == credenciais.EmailUsuario.ToLower());

            if (usuario == null || !Criptografia.VerificarPasswordHash(credenciais.PasswordUsuario, usuario.PasswordHash, usuario.PasswordSalt))
                return BadRequest("Usuário ou senha inválidos.");

            usuario.DataAcesso = DateTime.Now;
            _context.TB_USUARIOS.Update(usuario);
            await _context.SaveChangesAsync();

            usuario.PasswordHash = null;
            usuario.PasswordSalt = null;
            usuario.Token = CriarToken(usuario);

            return Ok(usuario);
        }
        #endregion

        #region Recuperação de Senha
      /* [AllowAnonymous]
[HttpPost("EsqueciSenha")]
public async Task<IActionResult> EsqueciSenha([FromBody] EsqueciSenhaDto request)
{
    if (string.IsNullOrEmpty(request.Email))
    {
        return BadRequest("O e-mail é obrigatório.");
    }

    var usuario = await _context.TB_USUARIOS
        .FirstOrDefaultAsync(x => x.EmailUsuario.ToLower() == request.Email.ToLower());

    if (usuario == null)
    {
        return BadRequest("Usuário não encontrado.");
    }

    // Gerar código e salvar no banco de dados
    string codigoRecuperacao = GerarCodigoSeguranca();
    usuario.CodigoRecuperacao = codigoRecuperacao;
    usuario.DataCodigoExpiracao = DateTime.Now.AddMinutes(30); // Código válido por 30 minutos

    _context.TB_USUARIOS.Update(usuario);
    await _context.SaveChangesAsync();

    // Enviar código por e-mail
    await _emailService.EnviarEmailAsync(request.Email, "Código de Recuperação", $"Seu código de recuperação é: {codigoRecuperacao}");

    return Ok("Código enviado para o seu e-mail.");
}


       [AllowAnonymous]
[HttpPost("ValidarCodigo")]
public async Task<IActionResult> ValidarCodigo([FromBody] RecuperacaoSenhaDto request)
{
    if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Codigo))
    {
        return BadRequest("E-mail e código são obrigatórios.");
    }

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



      [AllowAnonymous]
[HttpPost("MudandoSenha")]
public async Task<IActionResult> MudandoSenha([FromBody] MudancaSenhaDto request)
{
    try
    {
        if (string.IsNullOrEmpty(request.Codigo))
        {
            return BadRequest("O código de recuperação é obrigatório.");
        }

        if (request.NovaSenha != request.ConfirmarSenha)
        {
            return BadRequest("As senhas não coincidem.");
        }

        // Validar o código de segurança
        var usuario = await _context.TB_USUARIOS
            .FirstOrDefaultAsync(u => u.CodigoRecuperacao == request.Codigo && u.DataCodigoExpiracao.HasValue && u.DataCodigoExpiracao > DateTime.Now);

        if (usuario == null)
        {
            return BadRequest("Código inválido ou expirado.");
        }

        // Criptografar a nova senha
        Criptografia.CriarPasswordHash(request.NovaSenha, out byte[] hash, out byte[] salt);
        usuario.PasswordHash = hash;
        usuario.PasswordSalt = salt;
        usuario.DataCodigoExpiracao = null; // Limpar o código após a alteração de senha

        _context.TB_USUARIOS.Update(usuario);
        await _context.SaveChangesAsync();

        return Ok("Senha alterada com sucesso.");
    }
    catch (Exception ex)
    {
        return BadRequest($"Erro: {ex.Message}");
    }
}



        private string GerarCodigoSeguranca()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6); // Código de 6 dígitos
        }*/
        #endregion

        #region Consultas e Atualizações
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            List<Usuario> lista = await _context.TB_USUARIOS.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            Usuario? usuario = await _context.TB_USUARIOS
                .FirstOrDefaultAsync(x => x.IdUsuario == usuarioId);

            return Ok(usuario);
        }

        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail([FromBody] Usuario u)
        {
            Usuario? usuario = await _context.TB_USUARIOS
                .FirstOrDefaultAsync(x => x.IdUsuario == u.IdUsuario);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            usuario.EmailUsuario = u.EmailUsuario;

            _context.Entry(usuario).Property(x => x.EmailUsuario).IsModified = true;
            await _context.SaveChangesAsync();

            return Ok("E-mail atualizado com sucesso.");
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TCCEcoCria.Data;
using System.Security.Claims;
using TCCEcoCria.Models.Enuns;

namespace TCCEcoCria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaisController : ControllerBase
    {
        private readonly DataContext _context;
        public MateriaisController(DataContext context)
        {
            _context = context;
        }

    private static List<Materiais> TipoMaterial = new List<Materiais>()
    {
        new Materiais() { IdMaterial = 1, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico},
        new Materiais() { IdMaterial = 2, NomeMaterial = "Papelão", Material=MateriaisEnun.Papel},
        new Materiais() { IdMaterial = 3, NomeMaterial = "Saco Plástico", Material=MateriaisEnun.Plastico},
        new Materiais() { IdMaterial = 4, NomeMaterial = "Lata de Feijoada", Material=MateriaisEnun.Metal},
        new Materiais() { IdMaterial = 5, NomeMaterial = "Latinha", Material=MateriaisEnun.Metal},
        new Materiais() { IdMaterial = 6, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico},      
        new Materiais() { IdMaterial = 7, NomeMaterial = "Jarra de Vidro", Material=MateriaisEnun.Vidro}
    };

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
            Materiais m = await _context.TB_MATERIAIS.FirstOrDefaultAsync(x => x.IdMaterial == id);
            return Ok(m);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    

        [HttpPost]
        public async Task<IActionResult> AddMaterial(Materiais novoMaterial)
        {
            try
            {
                await _context.TB_MATERIAIS.AddAsync(novoMaterial);
                await _context.SaveChangesAsync();

                return Ok(novoMaterial.IdMaterial);

            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Materiais removerM = await _context.TB_MATERIAIS.FirstOrDefaultAsync(x => x.IdMaterial == id);
                _context.TB_MATERIAIS.Remove(removerM);
                int att = await _context.SaveChangesAsync();

                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }    
    
    }

    
    /*private int ObterUsuarioId() //retorna numero inteiro
        {
            return int.Parse(_httpContextAccessor.HttpContext.User //ira fazer leitura do token, para pegar ID
            .FindFirstValue(ClaimTypes.NameIdentifier));
        } */  

}
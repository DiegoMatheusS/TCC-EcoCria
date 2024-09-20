using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TCCEcoCria.Data;

namespace TCC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColetasController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ColetasController(DataContext context)
        {
            _context = context;
        }

        private static List<Coletas> TipoColeta = new List<Coletas>()
    {
        new Coletas() { IdColeta = 1, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 2, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 3, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 4, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 5, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 6, MomentoColeta = DateTime.Now},      
        new Coletas() { IdColeta = 7, MomentoColeta = DateTime.Now}
    }; 
    
        [HttpPost]
        public async Task<IActionResult> AddItem(Coletas? novaColeta)
        {
            try 
            {
                await _context.TB_COLETAS.AddAsync(novaColeta);
                await _context.SaveChangesAsync();

                var resultado = new 
                {
                    idColeta = novaColeta.IdColeta,
                    idPonto = novaColeta.IdPonto,
                    idUsuario = novaColeta.IdUsuario
                };

                return Ok(resultado);
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
                Coletas removerC = await _context.TB_COLETAS.FirstOrDefaultAsync(i => i.IdColeta == id);
                _context.TB_COLETAS.Remove(removerC);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {   
            try
            {
                Coletas c = await _context.TB_COLETAS.FirstOrDefaultAsync(busca => busca.IdColeta == id);

                return Ok (c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }   

        
    }
}
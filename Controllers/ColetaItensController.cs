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
    public class ColetaItensController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ColetaItensController(DataContext context)
        {
            _context = context;
        }

        private static List<ColetaItens> TipoColeta = new List<ColetaItens>()
    {
        new ColetaItens() { IdItemColeta = 1, QuantidadeColeta = 1},
        new ColetaItens() { IdItemColeta = 2, QuantidadeColeta = 2},
        new ColetaItens() { IdItemColeta = 3, QuantidadeColeta = 1},
        new ColetaItens() { IdItemColeta = 4, QuantidadeColeta = 2},
        new ColetaItens() { IdItemColeta = 5, QuantidadeColeta = 1},
        new ColetaItens() { IdItemColeta = 6, QuantidadeColeta = 2},      
        new ColetaItens() { IdItemColeta = 7, QuantidadeColeta = 1}
    }; 
    
        [HttpPost]
        public async Task<IActionResult> AddItem(ColetaItens novoItem)
        {
            try
            {
                await _context.TB_COLETAITENS.AddAsync(novoItem);
                await _context.SaveChangesAsync();

                var resultado = new 
                {
                    IdItemColeta = novoItem.IdColeta,
                    idMaterial = novoItem.IdMaterial,
                    idOrdemGrandeza = novoItem.IdOrdemGrandeza
                };

                return Ok(novoItem.IdItemColeta);
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
                ColetaItens removerCi = await _context.TB_COLETAITENS.FirstOrDefaultAsync(i => i.IdItemColeta == id);
                _context.TB_COLETAITENS.Remove(removerCi);
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
                ColetaItens ci = await _context.TB_COLETAITENS.FirstOrDefaultAsync(busca => busca.IdItemColeta == id);

                return Ok (ci);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }   

        
    }
}
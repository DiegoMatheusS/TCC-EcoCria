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
    public class PontosMateriaisController : ControllerBase
    {
        private readonly DataContext _context;
        
        public PontosMateriaisController(DataContext context)
        {
            _context = context;
        }

        private static List<PontoseMateriais> TipoPontoMaterial = new List<PontoseMateriais>()
        {
            new PontoseMateriais() { IdPontoMaterial = 1, DescricaoPontomaterial = "Somente Eletrônicos", StatusPontoMaterial = true},
            new PontoseMateriais() { IdPontoMaterial = 2, DescricaoPontomaterial = "Reciclagem em geral", StatusPontoMaterial = true},
            new PontoseMateriais() { IdPontoMaterial = 3, DescricaoPontomaterial = "Apenas descartes químicos", StatusPontoMaterial = true},
            new PontoseMateriais() { IdPontoMaterial = 4, DescricaoPontomaterial = "Reciclagem", StatusPontoMaterial = true},
            new PontoseMateriais() { IdPontoMaterial = 5, DescricaoPontomaterial = "Descarte de óleo", StatusPontoMaterial = true},
            new PontoseMateriais() { IdPontoMaterial = 6, DescricaoPontomaterial = "Entulhos", StatusPontoMaterial = true},      
            new PontoseMateriais() { IdPontoMaterial = 7, DescricaoPontomaterial = "Lixo", StatusPontoMaterial = true}
        };

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                PontoseMateriais pm = await _context.TB_PONTOSMATERIAIS.FirstOrDefaultAsync(x => x.IdPontoMaterial == id);

                return Ok(pm);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 


        
    }
}
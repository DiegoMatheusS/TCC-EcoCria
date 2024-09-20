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
    public class OrdemGrandezaController : ControllerBase
    {
        private readonly DataContext _context;
        
        public OrdemGrandezaController(DataContext context)
        {
            _context = context;
        }

        private static List<OrdemDeGrandeza> TipoGrandeza = new List<OrdemDeGrandeza>()
        {
            new OrdemDeGrandeza() { IdOrdemGrandeza = 1, DescricaoOrdemGrandeza ="Somente Eletrônicos"},
            new OrdemDeGrandeza() { IdOrdemGrandeza = 2, DescricaoOrdemGrandeza ="Reciclagem em geral"},
            new OrdemDeGrandeza() { IdOrdemGrandeza = 3, DescricaoOrdemGrandeza ="Apenas descartes químicos"},
            new OrdemDeGrandeza() { IdOrdemGrandeza = 4, DescricaoOrdemGrandeza ="Reciclagem"},
            new OrdemDeGrandeza() { IdOrdemGrandeza = 5, DescricaoOrdemGrandeza ="Descarte de óleo"},
            new OrdemDeGrandeza() { IdOrdemGrandeza = 6, DescricaoOrdemGrandeza ="Entulhos"},      
            new OrdemDeGrandeza() { IdOrdemGrandeza = 7, DescricaoOrdemGrandeza ="Lixo"}
        };

        [HttpPost]
        public async Task<IActionResult> AddOrdem(OrdemDeGrandeza novaGrandeza)
        {
            try 
            {
                await _context.TB_ORDEMGRANDEZA.AddAsync(novaGrandeza);
                await _context.SaveChangesAsync();
                
                return Ok(novaGrandeza.IdOrdemGrandeza);
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
                OrdemDeGrandeza o = await _context.TB_ORDEMGRANDEZA.FirstOrDefaultAsync(busca => busca.IdOrdemGrandeza == id);
                return Ok(o);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        } 

    }
}
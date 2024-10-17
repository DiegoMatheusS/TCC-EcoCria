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
    public class TrocasController : ControllerBase
    {
        private readonly DataContext _context;
        
        public TrocasController(DataContext context)
        {
            _context = context;
        }

         private static List<Trocas> TipoTroca = new List<Trocas>()
        {
            new Trocas() { IdTroca = 1, MomentoTroca= DateTime.Now},
            new Trocas() { IdTroca = 2, MomentoTroca= DateTime.Now},
            new Trocas() { IdTroca = 3, MomentoTroca= DateTime.Now},
            new Trocas() { IdTroca = 4, MomentoTroca= DateTime.Now},
            new Trocas() { IdTroca = 5, MomentoTroca= DateTime.Now},
            new Trocas() { IdTroca = 6, MomentoTroca= DateTime.Now},      
            new Trocas() { IdTroca = 7, MomentoTroca= DateTime.Now}
        };

        [HttpPost]
        public async Task<IActionResult> AddTroca(Trocas novaTroca)
        {
            try
            {
                await _context.TB_TROCAS.AddAsync(novaTroca);
                await _context.SaveChangesAsync();
                return Ok(novaTroca.IdTroca);
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
                Trocas t = await _context.TB_TROCAS.FirstOrDefaultAsync(x => x.IdTroca == id);
                return Ok (t);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        
    }
}
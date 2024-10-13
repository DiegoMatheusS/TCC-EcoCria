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
    public class TipoPontoController : ControllerBase
    {
        private readonly DataContext _context;
        
        public TipoPontoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPonto(TipoDePonto novoPonto)
        {
            try
            {
                await _context.TB_TIPOPONTO.AddAsync(novoPonto);
                  
                await _context.SaveChangesAsync();

                return Ok(novoPonto.IdTipoPonto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                TipoDePonto tp = await _context.TB_TIPOPONTO
                .Include(x => x.IdTipoPonto)
                .FirstOrDefaultAsync(bsc => bsc.IdTipoPonto == id);

                return Ok(tp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

    }
}
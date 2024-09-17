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
    public class PontosController : ControllerBase
    {
        private readonly DataContext _context;
        
        public PontosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPonto(Pontos novoPonto)
        {
            try
            {
                await _context.TB_PONTOS.AddAsync(novoPonto);
                await _context.SaveChangesAsync();

                return Ok (novoPonto.IdPonto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  

        [HttpPut]
        public async Task<IActionResult> Update(Pontos novoPonto)
        {
            try
            {
                if (novoPonto.UfEndereco != "SP")
                {
                    throw new System.Exception("Estado fora do alcance de busca. ");
                }
                    _context.TB_PONTOS.Update(novoPonto);
                    int alteracao = await _context.SaveChangesAsync();

                return Ok(alteracao);
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
                Pontos removerP = await _context.TB_PONTOS.FirstOrDefaultAsync(r => r.IdPonto == id);
                _context.TB_PONTOS.Remove(removerP);
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
                Pontos p = await _context.TB_PONTOS.FirstOrDefaultAsync(busca => busca.IdPonto == id);

                return Ok (p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }    

        
    }
}
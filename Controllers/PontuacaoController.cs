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
    public class PontuacaoController : ControllerBase
    {
        private readonly DataContext _context;
    
        public PontuacaoController(DataContext context)
        {
            _context = context;
        }

         private static List<Pontuacao> Pontuacao = new List<Pontuacao>()
        {
            new Pontuacao() { QuantidadePontos = 1, StatusPontos= true},
            new Pontuacao() { QuantidadePontos = 2, StatusPontos= true},
            new Pontuacao() { QuantidadePontos = 3, StatusPontos= true},
            new Pontuacao() { QuantidadePontos = 4, StatusPontos= true},
            new Pontuacao() { QuantidadePontos = 5, StatusPontos= true},
            new Pontuacao() { QuantidadePontos = 6, StatusPontos= true},      
            new Pontuacao() { QuantidadePontos = 7, StatusPontos= true}
        };

        [HttpPost]
        public async Task<IActionResult> AddPontos(Pontuacao novaPontucao)
        {
            try
            {
                await _context.TB_PONTUACAO.AddAsync(novaPontucao);
                await _context.SaveChangesAsync();

                return Ok(novaPontucao.IdPontuacao);
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
                Pontuacao p = await _context.TB_PONTUACAO.FirstOrDefaultAsync(x => x.IdPontuacao == id);
                return Ok(p);                
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
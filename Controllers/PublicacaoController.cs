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
    public class PublicacaoController : ControllerBase
    {
         private readonly DataContext _context;
        
        public PublicacaoController(DataContext context)
        {
            _context = context;
        }

         private static List<Publicacao> Publi = new List<Publicacao>()
        {
            new Publicacao() { IdPublicacao = 1, DataPublicacao= DateTime.Now, TituloPublicacao = "Resíduos", TextoPublicacao= "Hoje foi o dia de jogar esses resíduos fora." },
            new Publicacao() { IdPublicacao = 2, DataPublicacao= DateTime.Now, TituloPublicacao = "Descarte", TextoPublicacao= "Descartei corretamente o lixo."},
            new Publicacao() { IdPublicacao = 3, DataPublicacao= DateTime.Now, TituloPublicacao = "Coleta", TextoPublicacao= "E vamos de coleta!"},
            new Publicacao() { IdPublicacao = 4, DataPublicacao= DateTime.Now, TituloPublicacao = "Reciclando", TextoPublicacao = "Quem recicla ajuda."},
            new Publicacao() { IdPublicacao = 5, DataPublicacao= DateTime.Now, TituloPublicacao = "Bora reciclar", TextoPublicacao= "Testando esse método de reciclagem"},
            new Publicacao() { IdPublicacao = 6, DataPublicacao= DateTime.Now, TituloPublicacao = "Recicle!", TextoPublicacao= "Eu amo reciclar"},      
            new Publicacao() { IdPublicacao = 7, DataPublicacao= DateTime.Now, TituloPublicacao = "Ajudando o meio ambiente", TextoPublicacao= "Não vamos ficar parados, vamos todos reciclar!!"}
        };


        [HttpPost]
        public async Task<IActionResult> AddPublicacao(Publicacao novaPublicacao)
        {
            try
            {
                await _context.TB_PUBLICACAO.AddAsync(novaPublicacao);
                await _context.SaveChangesAsync();

                return Ok(novaPublicacao.IdPublicacao);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpPut]
        public async Task<IActionResult> UpdatePublicacao(Publicacao novaPublicacao)
        {
            try
            {
                _context.TB_PUBLICACAO.Update(novaPublicacao);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
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
                Publicacao removerP = await _context.TB_PUBLICACAO.FirstOrDefaultAsync(x => x.IdPublicacao == id);
                _context.TB_PUBLICACAO.Remove(removerP);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
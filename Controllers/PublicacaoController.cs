using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddPublicacao(Publicacao novaPublicacao)
        {
            Publi.Add(novaPublicacao);
            return Ok(Publi);
        } 

        [HttpPut]
        public IActionResult UpdatePublicacao(Publicacao i)
        {
            Publicacao publicacaoAlterada = Publi.Find(mat => mat.IdPublicacao == i.IdPublicacao);
            publicacaoAlterada.TituloPublicacao = i.TituloPublicacao;
            publicacaoAlterada.TextoPublicacao = i.TextoPublicacao;

            return Ok(Publi);
        } 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Publi.RemoveAll(mat => mat.IdPublicacao == id);

            return Ok(Publi);
        }
        
    }
}
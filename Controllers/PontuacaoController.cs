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
        public IActionResult AddPontos(Pontuacao novaPontucao)
        {
            Pontuacao.Add(novaPontucao);
            return Ok(Pontuacao);
        }

        /*[HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(Pontucao.FirstOrDefault(mat => mat.novaPontucao == id));
        } */

        
    }
}
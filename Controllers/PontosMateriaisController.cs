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
    public class PontosMateriaisController : ControllerBase
    {
        private readonly DataContext _context;
        
        public PontosMateriaisController(DataContext context)
        {
            _context = context;
        }

        private static List<PontoseMateriais> TipoPontoMaterial = new List<PontoseMateriais>()
        {
            new PontoseMateriais() { DescricaoPontomaterial = "Somente Eletrônicos", StatusPontoMaterial = true},
            new PontoseMateriais() { DescricaoPontomaterial = "Reciclagem em geral", StatusPontoMaterial = true},
            new PontoseMateriais() { DescricaoPontomaterial = "Apenas descartes químicos", StatusPontoMaterial = true},
            new PontoseMateriais() { DescricaoPontomaterial = "Reciclagem", StatusPontoMaterial = true},
            new PontoseMateriais() { DescricaoPontomaterial = "Descarte de óleo", StatusPontoMaterial = true},
            new PontoseMateriais() { DescricaoPontomaterial = "Entulhos", StatusPontoMaterial = true},      
            new PontoseMateriais() { DescricaoPontomaterial = "Lixo", StatusPontoMaterial = true}
        };

       /* [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
           return Ok(PontosMateriais.FirstOrDefault(mat => mat.IdPonto == id));
        } */

        
    }
}
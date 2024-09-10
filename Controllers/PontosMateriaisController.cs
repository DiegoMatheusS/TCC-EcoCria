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
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Somente Eletrônicos"},
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Reciclagem em geral"},
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Apenas descartes químicos"},
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Reciclagem"},
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Descarte de óleo"},
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Entulhos"},      
            new PontoseMateriais() { DescricaoPontomaterial = "", StatusPontoMaterial ="Lixo"}
        };

       /* [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
           return Ok(PontosMateriais.FirstOrDefault(mat => mat.IdPonto == id));
        } */

        
    }
}
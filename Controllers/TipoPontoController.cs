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
    public class TipoPontoController : ControllerBase
    {
        private readonly DataContext _context;
        
        public TipoPontoController(DataContext context)
        {
            _context = context;
        }

        private static List<TipoDePonto> TipoPonto = new List<TipoDePonto>()
        {
            new TipoDePonto() { IdTipoPonto = 1, DescricaoTipoPonto ="Somente Eletrônicos", StatusTipoPonto = true},
            new TipoDePonto() { IdTipoPonto = 2, DescricaoTipoPonto ="Reciclagem em geral", StatusTipoPonto = true},
            new TipoDePonto() { IdTipoPonto = 3, DescricaoTipoPonto ="Apenas descartes químicos", StatusTipoPonto = true},
            new TipoDePonto() { IdTipoPonto = 4, DescricaoTipoPonto ="Reciclagem", StatusTipoPonto = true},
            new TipoDePonto() { IdTipoPonto = 5, DescricaoTipoPonto ="Descarte de óleo", StatusTipoPonto = true},
            new TipoDePonto() { IdTipoPonto = 6, DescricaoTipoPonto ="Entulhos", StatusTipoPonto = true},      
            new TipoDePonto() { IdTipoPonto = 7, DescricaoTipoPonto ="Lixo", StatusTipoPonto = true}
        };

        [HttpPost]
        public IActionResult AddPonto(TipoDePonto novoPonto)
        {
            TipoPonto.Add(novoPonto);
            return Ok(TipoPonto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoPonto.FirstOrDefault(mat => mat.IdTipoPonto == id));
        } 

    }
}
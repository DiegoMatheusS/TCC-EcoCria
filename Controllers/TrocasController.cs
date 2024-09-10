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
        public IActionResult AddTroca(Trocas novaTroca)
        {
            TipoTroca.Add(novaTroca);
            return Ok(TipoTroca);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoTroca.FirstOrDefault(mat => mat.IdTroca == id));
        } 

        
    }
}
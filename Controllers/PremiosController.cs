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
    public class PremiosController : ControllerBase
    {
        private readonly DataContext _context;
        
        public PremiosController(DataContext context)
        {
            _context = context;
        }

         private static List<Premios> TipoPremio = new List<Premios>()
        {
            new Premios() { IdPremio = 1, DescricaoPremio= "Acréscimo de 5%", QuantidadePremio = 1, PontosPremio= 10},
            new Premios() { IdPremio = 2, DescricaoPremio= "Acréscimo de 10%", QuantidadePremio = 1, PontosPremio= 10 },
            new Premios() { IdPremio = 3, DescricaoPremio= "Acréscimo de 15%", QuantidadePremio = 1, PontosPremio= 10},
            new Premios() { IdPremio = 4, DescricaoPremio= "Acréscimo de 20%", QuantidadePremio = 1, PontosPremio = 10},
            new Premios() { IdPremio = 5, DescricaoPremio= "Acréscimo de 25%", QuantidadePremio = 1, PontosPremio= 10},
            new Premios() { IdPremio = 6, DescricaoPremio= "Acréscimo de 30%", QuantidadePremio = 1, PontosPremio= 10},      
            new Premios() { IdPremio = 7, DescricaoPremio= "Acréscimo de 50%", QuantidadePremio = 1, PontosPremio= 10}
        };

        /*[HttpPost]
        public async Task<IActionResult> AddPremio(Premios novoPremio)
        {
            try
            {
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
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

     */   
    }
}
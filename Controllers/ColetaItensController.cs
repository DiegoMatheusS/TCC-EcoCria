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
    public class ColetaItensController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ColetaItensController(DataContext context)
        {
            _context = context;
        }

        private static List<ColetaItens> TipoColeta = new List<ColetaItens>()
    {
        new ColetaItens() { IdItemColeta = 1, QuantidadeColeta = 1},
        new ColetaItens() { IdItemColeta = 2, QuantidadeColeta = 2},
        new ColetaItens() { IdItemColeta = 3, QuantidadeColeta = 1},
        new ColetaItens() { IdItemColeta = 4, QuantidadeColeta = 2},
        new ColetaItens() { IdItemColeta = 5, QuantidadeColeta = 1},
        new ColetaItens() { IdItemColeta = 6, QuantidadeColeta = 2},      
        new ColetaItens() { IdItemColeta = 7, QuantidadeColeta = 1}
    }; 
    
        [HttpPost]
        public IActionResult AddItem(ColetaItens novoItem)
        {
            TipoColeta.Add(novoItem);
            return Ok(TipoColeta);
        }  

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoColeta.RemoveAll(mat => mat.IdItemColeta == id);

            return Ok(TipoColeta);
        }

        
    }
}
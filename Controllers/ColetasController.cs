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
    public class ColetasController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ColetasController(DataContext context)
        {
            _context = context;
        }

        private static List<Coletas> TipoColeta = new List<Coletas>()
    {
        new Coletas() { IdColeta = 1, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 2, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 3, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 4, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 5, MomentoColeta = DateTime.Now},
        new Coletas() { IdColeta = 6, MomentoColeta = DateTime.Now},      
        new Coletas() { IdColeta = 7, MomentoColeta = DateTime.Now}
    }; 
    
        [HttpPost]
        public IActionResult AddItem(Coletas novoItem)
        {
            TipoColeta.Add(novoItem);
            return Ok(TipoColeta);
        }  

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoColeta.RemoveAll(mat => mat.IdColeta == id);

            return Ok(TipoColeta);
        }

        
    }
}
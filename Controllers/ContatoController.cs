using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOCRIA.Models;
using Microsoft.AspNetCore.Mvc;
using TCCEcoCria.Data;

namespace ECOCRIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly DataContext _context;
        public ContatoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddContato(Contato novoContato)
        {
            try 
            {
                await _context.TB_CONTATO.AddAsync(novoContato);
                await _context.SaveChangesAsync();

                return Ok(novoContato.IdContato);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  

    }
}
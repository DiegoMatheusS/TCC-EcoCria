using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using TCCEcoCria.Data;

namespace ECOCRIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly DataContext _context;
    
        public TipoUsuarioController(DataContext context)
        {
            _context = context;
        }
/*
        [HttpPost]
        public async Task<IActionResult> AddTipoUsuario(TipoUsuario novoTipoUsuario)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public async Task<IActionResult> AddTipoUsuario(TipoUsuario novoTipoUsuario)
        {
            try
            {
                await _context.TB_TIPOUSUARIO.AddAsync(novoTipoUsuario);
                await _context.SaveChangesAsync();
                return Ok(novoTipoUsuario.IdTipoUsuario);
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
                TipoUsuario tp = await _context.TB_TIPOUSUARIO.FirstOrDefaultAsync(x => x.IdTipoUsuario == id);
                _context.TB_TIPOUSUARIO.Remove(tp);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpPut("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario(TipoUsuario u)
        {
            try
            {
                TipoUsuario usuario = await _context.TB_TIPOUSUARIO.FirstOrDefaultAsync(x => x.IdTipoUsuario == u.IdUsuario);

                int att = await _context.SaveChangesAsync(); 
                return Ok(att); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
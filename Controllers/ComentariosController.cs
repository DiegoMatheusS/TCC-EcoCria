using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TCCEcoCria.Data;

namespace TCC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ComentariosController(DataContext context)
        {
            _context = context;
        }

        private static List<Comentarios> TipoComentario = new List<Comentarios>()
        {
            new Comentarios() { IdComentario = 1, MomentoComentario= DateTime.Now, TextoComentario = "Isso aí"},
            new Comentarios() { IdComentario = 2, MomentoComentario= DateTime.Now, TextoComentario = "Ajudando nosso planeta"},
            new Comentarios() { IdComentario = 3, MomentoComentario= DateTime.Now, TextoComentario = "Muito bom"},
            new Comentarios() { IdComentario = 4, MomentoComentario= DateTime.Now, TextoComentario = "Reciclar é bom mesmo"},
            new Comentarios() { IdComentario = 5, MomentoComentario= DateTime.Now, TextoComentario = "Continue assim"},
            new Comentarios() { IdComentario = 6, MomentoComentario= DateTime.Now, TextoComentario = "Bora lá"},      
            new Comentarios() { IdComentario = 7, MomentoComentario= DateTime.Now, TextoComentario = "Eu faço muito isso"}
        };


        [HttpPost]
        public async Task<IActionResult> AddComentario(Comentarios novoComentario)
        {
            try
            {
                await _context.TB_COMENTARIOS.AddAsync(novoComentario);
                await _context.SaveChangesAsync();
                return Ok(novoComentario.IdComentario);
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
                Comentarios c = await _context.TB_COMENTARIOS.FirstOrDefaultAsync(x => x.IdComentario == id);
                return Ok (c);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Comentarios removerC = await _context.TB_COMENTARIOS.FirstOrDefaultAsync(x => x.IdComentario == id);

                _context.TB_COMENTARIOS.Remove(removerC);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComentario(Comentarios novoComentario)
        {
            try
            {
                _context.TB_COMENTARIOS.Update(novoComentario);
                int att = await _context.SaveChangesAsync();
                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        
    }
}
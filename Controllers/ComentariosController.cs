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
        public IActionResult AddComentario(Comentarios novoComentario)
        {
            TipoComentario.Add(novoComentario);
            return Ok(TipoComentario);
        } 

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoComentario.FirstOrDefault(mat => mat.IdComentario == id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoComentario.RemoveAll(mat => mat.IdComentario == id);

            return Ok(TipoComentario);
        }

        [HttpPut]
        public IActionResult UpdateComentario(Comentarios i)
        {
            Comentarios parceiroAlterado = TipoComentario.Find(mat => mat.IdComentario == i.IdComentario);
            parceiroAlterado.TextoComentario = i.TextoComentario;

            return Ok(TipoComentario);
        } 



        
    }
}
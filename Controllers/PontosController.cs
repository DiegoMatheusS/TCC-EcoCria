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
    public class PontosController : ControllerBase
    {
        private readonly DataContext _context;
        
        public PontosController(DataContext context)
        {
            _context = context;
        }

        private static List<Pontos> TipoPonto = new List<Pontos>()
    {
        new Pontos() { IdPonto = 1, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678},
        new Pontos() { IdPonto = 2, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678},
        new Pontos() { IdPonto = 3, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678},
        new Pontos() { IdPonto = 4, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678},
        new Pontos() { IdPonto = 5, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678},
        new Pontos() { IdPonto = 6, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678},      
        new Pontos() { IdPonto = 7, NomePonto = "", EnderecoPonto= "", CidadeEndereco= "", UfEndereco= "", CepEndereco= 12345678}
    };

        [HttpPost]
        public IActionResult AddPonto(Pontos novoPonto)
        {
            TipoPonto.Add(novoPonto);
            return Ok(TipoPonto);
        }  

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoPonto.RemoveAll(mat => mat.IdPonto == id);

            return Ok(TipoPonto);
        }   

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoPonto.FirstOrDefault(mat => mat.IdPonto == id));
        }    

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TCCEcoCria.Data;
using System.Security.Claims;
using TCCEcoCria.Models.Enuns;

namespace TCCEcoCria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaisController : ControllerBase
    {
        private readonly DataContext _context;
        public MateriaisController(DataContext context)
        {
            _context = context;
        }

   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
            Materiais m = await _context.TB_MATERIAIS.FirstOrDefaultAsync(x => x.IdMaterial == id);
            return Ok(m);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    

        [HttpPost]
        public async Task<IActionResult> AddMaterial(Materiais novoMaterial)
        {
            try
            {
                await _context.TB_MATERIAIS.AddAsync(novoMaterial);
                await _context.SaveChangesAsync();

                return Ok(novoMaterial.IdMaterial);

            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Materiais> lista = await _context.TB_MATERIAIS.ToListAsync();

                return Ok(lista);
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
                Materiais removerM = await _context.TB_MATERIAIS.FirstOrDefaultAsync(x => x.IdMaterial == id);
                _context.TB_MATERIAIS.Remove(removerM);
                int att = await _context.SaveChangesAsync();

                return Ok(att);
            }
            catch(System.Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }    
    
    }

    
    /*private int ObterUsuarioId() //retorna numero inteiro
        {
            return int.Parse(_httpContextAccessor.HttpContext.User //ira fazer leitura do token, para pegar ID
            .FindFirstValue(ClaimTypes.NameIdentifier));
        } */  

}
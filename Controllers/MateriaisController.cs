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




    /*private int ObterUsuarioId() //retorna numero inteiro
        {
            return int.Parse(_httpContextAccessor.HttpContext.User //ira fazer leitura do token, para pegar ID
            .FindFirstValue(ClaimTypes.NameIdentifier));
        } */  





   /* [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Materiais? p = await _context.TB_MATERIAIS               
                    .Include(us => us.Usuario)   //Inclui na propriedade Usuario do objeto p
                    //.Include(pm => pm.PontosMateriais)                        
                    .FirstOrDefaultAsync(pBusca => pBusca.IdMaterial == id);

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

    private static List<Materiais> TipoMaterial = new List<Materiais>()
    {
        new Materiais() { IdMaterial = 1, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico, IdUsuario = 1 },
        new Materiais() { IdMaterial = 2, NomeMaterial = "Papelão", Material=MateriaisEnun.Papel, IdUsuario = 1 },
        new Materiais() { IdMaterial = 3, NomeMaterial = "Saco Plástico", Material=MateriaisEnun.Plastico, IdUsuario = 1 },
        new Materiais() { IdMaterial = 4, NomeMaterial = "Lata de Feijoada", Material=MateriaisEnun.Metal, IdUsuario = 1 },
        new Materiais() { IdMaterial = 5, NomeMaterial = "Latinha", Material=MateriaisEnun.Metal, IdUsuario = 1 },
        new Materiais() { IdMaterial = 6, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico, IdUsuario = 1 },      
        new Materiais() { IdMaterial = 7, NomeMaterial = "Jarra de Vidro", Material=MateriaisEnun.Vidro, IdUsuario = 1 }
    };

    [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(TipoMaterial);
        }

    [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoMaterial.FirstOrDefault(mat => mat.IdMaterial == id));
        }    

    [HttpPost]
        public IActionResult AddMaterial(Materiais novoMaterial)
        {
            TipoMaterial.Add(novoMaterial);
            return Ok(TipoMaterial);
        }  

    [HttpPut]
        public IActionResult UpdateMaterial(Materiais i)
        {
            Materiais materialAlterado = TipoMaterial.Find(mat => mat.IdMaterial == i.IdMaterial);
            materialAlterado.NomeMaterial = i.NomeMaterial;

            return Ok(TipoMaterial);
        } 

    [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoMaterial.RemoveAll(mat => mat.IdMaterial == id);

            return Ok(TipoMaterial);
        }    
    
    }
}
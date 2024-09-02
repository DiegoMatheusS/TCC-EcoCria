using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TCCEcoCria.Data;

namespace TCCEcoCria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParceirosController : ControllerBase
    {
        private readonly DataContext _context;
        public ParceirosController(DataContext context)
        {
            _context = context;
        }
         private static List<Parceiros> TipoParceiro = new List<Parceiros>()
        {
            new Parceiros() { IdParceiro = 1, StatusParceiro= false, NomeParceiro = "Empresa BlaBla", DoacaoParceiro= 500.99, DataDoacao = DateTime.Now, IdUsuario = 1 },
            new Parceiros() { IdParceiro = 2, StatusParceiro= true, NomeParceiro = "Market Empresa", DoacaoParceiro= 500.56 , DataDoacao = DateTime.Now, IdUsuario = 2 },
            new Parceiros() { IdParceiro = 3, StatusParceiro= false, NomeParceiro = "Empresa Eletro", DoacaoParceiro= 1500.10, DataDoacao = DateTime.Now, IdUsuario = 3 },
            new Parceiros() { IdParceiro = 4, StatusParceiro= true, NomeParceiro = "Empresa Papel", DoacaoParceiro = 5500, DataDoacao = DateTime.Now, IdUsuario = 4 },
            new Parceiros() { IdParceiro = 5, StatusParceiro= true, NomeParceiro = "Empresa Rainiken", DoacaoParceiro= 2500.20, DataDoacao = DateTime.Now, IdUsuario = 5 },
            new Parceiros() { IdParceiro = 6, StatusParceiro= false, NomeParceiro = "Empresa squol", DoacaoParceiro= 5000.00, DataDoacao = DateTime.Now, IdUsuario = 6 },      
            new Parceiros() { IdParceiro = 7, StatusParceiro= true, NomeParceiro = "Empresa suifiti", DoacaoParceiro= 10500.95, DataDoacao = DateTime.Now, IdUsuario = 7 }
        };

       /* [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Parceiros? p = await _context.TB_PARCEIROS               
                    .Include(us => us.IdUsuario)   //Inclui na propriedade Usuario do objeto                   
                    .FirstOrDefaultAsync(pBusca => pBusca.IdParceiro == id);

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Parceiros> lista = await _context.TB_PARCEIROS.ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }*/
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(TipoParceiro);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(TipoParceiro.FirstOrDefault(mat => mat.IdParceiro == id));
        } 


        [HttpPut]
        public IActionResult UpdateParceiro(Parceiros i)
        {
            Parceiros parceiroAlterado = TipoParceiro.Find(mat => mat.IdParceiro == i.IdParceiro);
            parceiroAlterado.NomeParceiro = i.NomeParceiro;
            parceiroAlterado.DoacaoParceiro = i.DoacaoParceiro;
            parceiroAlterado.DataDoacao = i.DataDoacao;

            return Ok(TipoParceiro);
        } 

        [HttpPost]
        public IActionResult AddParceiro(Parceiros novoParceiro)
        {
            TipoParceiro.Add(novoParceiro);
            return Ok(TipoParceiro);
        }  

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoParceiro.RemoveAll(mat => mat.IdParceiro == id);

            return Ok(TipoParceiro);
        } 











    }
}
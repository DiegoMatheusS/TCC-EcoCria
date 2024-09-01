using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCEcoCria.Data;
using TCCEcoCria.Interfaces;

namespace TCCEcoCria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly DataContext _context;
        public readonly IEnderecoServices _enderecoServices;

        public EnderecoController(IEnderecoServices enderecoServices, DataContext context )
        {
            _enderecoServices = enderecoServices;
            _context = context;

        }
        


        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> BuscarEndereco([FromRoute]string cep)
        {
            var response  = await _enderecoServices.BuscarEndereco(cep);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }




    }
}
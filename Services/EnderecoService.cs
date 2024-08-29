using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TCCEcoCria.Dtos;
using TCCEcoCria.Interfaces;

namespace TCCEcoCria.Services
{
    public class EnderecoService : IEnderecoServices
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public EnderecoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep)
        {
            var endereco = await _brasilApi.BuscarEnderecoPorCEP(cep);
            return _mapper.Map<ResponseGenerico<EnderecoResponse>>(endereco);
        }
    }
}
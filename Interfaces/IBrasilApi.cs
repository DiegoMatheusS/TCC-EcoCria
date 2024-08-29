using TCCEcoCria.Dtos;
using TCCEcoCria.Models;

namespace TCCEcoCria.Interfaces
{
    public interface IBrasilApi
    {
        Task<ResponseGenerico<Endereco>> BuscarEnderecoPorCEP(string cep);
    }
}
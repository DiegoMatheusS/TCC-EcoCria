using TCCEcoCria.Dtos;

namespace TCCEcoCria.Interfaces
{
    public interface IEnderecoServices
    {
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);

    }
}
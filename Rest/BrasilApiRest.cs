using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TCCEcoCria.Dtos;
using TCCEcoCria.Interfaces;
using TCCEcoCria.Models;

namespace TCCEcoCria.Rest
{
    public class BrasilApiRest : IBrasilApi
    {
       public async Task<ResponseGenerico<Endereco>> BuscarEnderecoPorCEP(string cep)
       {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v2/{cep}");

            var response = new ResponseGenerico<Endereco>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Endereco>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;

       }
    }
}
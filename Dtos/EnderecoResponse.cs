using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCCEcoCria.Dtos
{
    public class EnderecoResponse
    {
         
        public string? Cep { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Regiao { get; set; }
        public string? Rua { get; set; }
        
        
        public List<LocacaoResponse> Tipo { get; set; } = new List<LocacaoResponse>();
        public List<CoordenadasResponse> Latitude { get; set; } = new List<CoordenadasResponse>{ };
        public List<CoordenadasResponse> Longitude { get; set; } = new List<CoordenadasResponse>{ };




        [JsonIgnore]        
        public string? Servico { get; set; }
        
    }
}
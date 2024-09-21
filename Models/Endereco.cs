using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TCCEcoCria.Models
{
    public class Endereco
    {
        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("state")]
        public string? Estado { get; set; }

        [JsonPropertyName("city")]
        public string? Cidade { get; set; }

        [JsonPropertyName("neighborhood")]
        public string? Regiao { get; set; }

        [JsonPropertyName("street")]
        public string? Rua { get; set; }

        [JsonPropertyName("service")]
        public string? Servico { get; set; }

        public List<Locacao> Tipo { get; set; } = new List<Locacao>();


        public List<Coordenadas> Latitude { get; set; } = new List<Coordenadas>{ };


        public List<Coordenadas> Longitude { get; set; } = new List<Coordenadas>{ };

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Pontos
    {
        public int IdPonto { get; set; }
        public string NomePonto { get; set; } = string.Empty;
        public string EnderecoPonto { get; set; } = string.Empty;
        public int CepEndereco { get; set; }
        public string UfEndereco { get; set; } = string.Empty;
        public string CidadeEndereco { get; set; } = string.Empty;

        public int IdTipoPonto { get; set; }

        [JsonIgnore]
        public TipoDePonto TipoPonto { get; set; }  // Relacionamento com TipoDePonto

        [JsonIgnore]
        public List<Coletas>? Coletas { get; set; }  // Relacionamento com Coletas

 

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Pontuacao
    {
        public int IdPontuacao { get; set; }
        public int QuantidadePontos { get; set; }
        public Boolean StatusPontos { get; set; } 
        public int? IdUsuario { get; set; }
        public int? IdColeta { get; set;}

        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        
        [JsonIgnore]
        public Coletas? Coletas { get; set; }
    }
}
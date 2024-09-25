using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Pontuacao
    {
        public int QuantidadePontos { get; set; }
        public Boolean StatusPontos { get; set; } 

        public Usuario? Usuario { get; set; }

        public int IdUsuario { get; set; }
    }
}
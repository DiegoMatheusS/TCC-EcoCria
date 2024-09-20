using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PontoseMateriais
    {
        public int IdPontoMaterial { get; set; }
        public string DescricaoPontomaterial { get; set; } = string.Empty;
        public Boolean StatusPontoMaterial { get; set; }
        public int IdPonto { get; set; }
        public int IdMaterial { get; set; }
        public Materiais? Materiais { get; set; }
        public Pontos? Pontos { get; set; }
    }
}
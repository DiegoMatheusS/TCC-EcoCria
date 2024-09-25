using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class ColetaItens
    {
        public int IdItemColeta { get; set; }
        public int QuantidadeColeta { get; set; }
        public int? IdColeta { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOrdemGrandeza { get; set; }
        public Coletas? Coletas { get; set; }
        public Materiais? Materiais { get; set; }
        public OrdemDeGrandeza? OrdemDeGrandeza { get; set; }

    }
}
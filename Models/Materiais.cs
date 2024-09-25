using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TCCEcoCria.Models.Enuns;

namespace Models
{
    public class Materiais
    {
        public int IdMaterial { get; set; }
        public string NomeMaterial { get; set; } = string.Empty;
        public int IdOrdemGrandeza { get; set; }
        public MateriaisEnun Material { get; set; }
        public OrdemDeGrandeza? OrdemDeGrandeza { get; set; }
        
        [JsonIgnore]
        public List<ColetaItens>? ColetaItens { get; set; }

        /*[JsonIgnore]
        public PontoseMateriais? PontoseMateriais { get; set; }*/
    }
}
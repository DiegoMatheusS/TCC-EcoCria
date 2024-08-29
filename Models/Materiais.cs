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
        public MateriaisEnun Material { get; set; }


        public int? IdUsuario { get; set; }  


        [JsonIgnore]
        public Usuario? Usuario { get; set; }


        [JsonIgnore]
        public PontoseMateriais? PontoseMateriais { get; set; }
    }
}
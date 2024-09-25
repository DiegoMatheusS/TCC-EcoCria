using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class OrdemDeGrandeza
    {
        public int IdOrdemGrandeza { get; set; }
        public string DescricaoOrdemGrandeza { get; set; } = string.Empty;

        [JsonIgnore]
        public List<ColetaItens>? ColetaItens { get; set; }
    }
}
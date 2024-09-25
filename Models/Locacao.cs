using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCCEcoCria.Models
{
    public class Locacao
    {
        [JsonPropertyName("type")]
        public string? Tipo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class ValidacaoCodigoRequest
    {
        public string Email { get; set; }
        public string Codigo { get; set; }
    }
}

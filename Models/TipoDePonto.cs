using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class TipoDePonto
    {
        public int IdTipoPonto { get; set; }
        public string DescricaoTipoPonto { get; set; } = string.Empty;
        public Boolean StatusTipoPonto { get; set; }
    }
}
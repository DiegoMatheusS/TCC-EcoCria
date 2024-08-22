using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Parceiros
    {
        public int IdParceiro { get; set; }
        public string NomeParceiro { get; set; } = string.Empty;
        public Boolean StatusParceiro { get; set; }
        public double DoacaoParceiro { get; set; }
        public DateTime DataDoacao { get; set; }
    }
}
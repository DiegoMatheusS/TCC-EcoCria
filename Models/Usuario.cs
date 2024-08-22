using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String NomeUsuario { get; set; } = string.Empty;
        public String EmailUsuario { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public String PasswordUsuario { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime?  DataAcesso { get; set; }
        public string Token { get; set; } = string.Empty;

    }
}
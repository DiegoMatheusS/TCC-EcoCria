using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Perfil { get; set; }  = string.Empty;
        public string EmailUsuario { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime?  DataAcesso { get; set; }
        public byte[]? FotoUsuario { get; set; }

        [NotMapped]
        public string PasswordUsuario { get; set; } = string.Empty;

        [NotMapped]
        public string Token { get; set; } = string.Empty;


        [JsonIgnore]
        public List<Parceiros>? Parceiros { get; set; }
        
        [JsonIgnore]
        public List<Coletas>? Coletas {get; set;} 


    }
}
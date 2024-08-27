using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models;
using RpgApi.Utils;

namespace TCCEcoCria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
            
        }

        public DbSet<Materiais> TB_MATERIAIS{ get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materiais>().ToTable("TB_MATERIAIS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            //Relacionamento One to Many (Um para muitos)
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Materiais)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired(false);

         modelBuilder.Entity<Materiais>().HasData
            (
                new Materiais() { IdMaterial = 1, NomeMaterial = "Garrafa Pet", Cor= "Transparente", IdUsuario = 1 },
                new Materiais() { IdMaterial = 2, NomeMaterial = "Latinha", Cor= "Prata", IdUsuario = 1 },
                new Materiais() { IdMaterial = 3, NomeMaterial = "Papelão", Cor= "Bege", IdUsuario = 1 },
                new Materiais() { IdMaterial = 4, NomeMaterial = "Vidro", Cor= "Transparente", IdUsuario = 1 },
                new Materiais() { IdMaterial = 5, NomeMaterial = "Saco Plástico", Cor= "Colorido", IdUsuario = 1 },
                new Materiais() { IdMaterial = 6, NomeMaterial = "Óleo", Cor= "Amarelo", IdUsuario = 1 },
                new Materiais() { IdMaterial = 7, NomeMaterial = "Garrafa Pet", Cor= "Verde Transparente", IdUsuario = 1 }
            );


            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[]hash, out byte[]salt);
            user.Id = 1;
            user.Username = "admin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordHash = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gamil.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Cliente");

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models;
using TCCEcoCria.Utils;
using TCCEcoCria.Models.Enuns;

namespace TCCEcoCria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Materiais> TB_MATERIAIS{ get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }
        public DbSet<Parceiros> TB_PARCEIROS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materiais>().ToTable("TB_MATERIAIS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().ToTable("TB_PARCEIROS");


            //Relacionamento One to Many (Um para muitos)
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Materiais)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired(false);

             modelBuilder.Entity<Materiais>()
                .HasKey(x => new {x.IdMaterial});

                modelBuilder.Entity<Usuario>()
                .HasKey(x => new {x.IdUsuario});


        modelBuilder.Entity<Materiais>().HasData
        (
            new Materiais() { IdMaterial = 1, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico, IdUsuario = 1 },
            new Materiais() { IdMaterial = 2, NomeMaterial = "Papelão", Material=MateriaisEnun.Papel, IdUsuario = 1 },
            new Materiais() { IdMaterial = 3, NomeMaterial = "Saco Plástico", Material=MateriaisEnun.Plastico, IdUsuario = 1 },
            new Materiais() { IdMaterial = 4, NomeMaterial = "Lata de Feijoada", Material=MateriaisEnun.Metal, IdUsuario = 1 },
            new Materiais() { IdMaterial = 5, NomeMaterial = "Latinha", Material=MateriaisEnun.Metal, IdUsuario = 1 },
            new Materiais() { IdMaterial = 6, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico, IdUsuario = 1 },      
            new Materiais() { IdMaterial = 7, NomeMaterial = "Jarra de Vidro", Material=MateriaisEnun.Vidro, IdUsuario = 1 }
        );

        modelBuilder.Entity<Parceiros>().HasData
        (
            new Parceiros() { IdParceiro = 1, NomeParceiro = "Empresa BlaBla", DoacaoParceiro= 500, IdUsuario = 1 },
            new Parceiros() { IdParceiro = 2, NomeParceiro = "Market Empresa", DoacaoParceiro= 500 , IdUsuario = 2 },
            new Parceiros() { IdParceiro = 3, NomeParceiro = "Empresa Eletro", DoacaoParceiro= 500, IdUsuario = 3 },
            new Parceiros() { IdParceiro = 4, NomeParceiro = "Empresa Papel", DoacaoParceiro= 500, IdUsuario = 4 },
            new Parceiros() { IdParceiro = 5, NomeParceiro = "Empresa Rainiken", DoacaoParceiro= 500, IdUsuario = 5 },
            new Parceiros() { IdParceiro = 6, NomeParceiro = "Empresa squol", DoacaoParceiro= 500, IdUsuario = 6 },      
            new Parceiros() { IdParceiro = 7, NomeParceiro = "Empresa suifiti", DoacaoParceiro= 500, IdUsuario = 7 }
        );




            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[]hash, out byte[]salt);
            user.IdUsuario = 1;
            user.NomeUsuario = "admin";
            user.PasswordUsuario = string.Empty;
            user.PasswordHash = hash;
            user.PasswordHash = salt;
            user.Perfil = "Admin";
            user.EmailUsuario = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Cliente");

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)//convensao para configurar a base, regras
        {
            configurationBuilder.Properties<string>().HaveColumnType("Varchar").HaveMaxLength(200);
        }

    }
}
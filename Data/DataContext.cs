using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models;
using TCCEcoCria.Utils;
using TCCEcoCria.Models.Enuns;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCEcoCria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Materiais> TB_MATERIAIS{ get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }
        public DbSet<Parceiros> TB_PARCEIROS { get; set; }
        public DbSet<Coletas> TB_COLETAS{get; set;}
        public DbSet<ColetaItens> TB_COLETAITENS{get; set;}
        public DbSet<Comentarios> TB_COMENTARIOS{get; set;}
        public DbSet<OrdemDeGrandeza> TB_ORDEMGRANDEZA{get; set;}
        public DbSet<Pontos> TB_PONTOS{get; set;}
        public DbSet<PontoseMateriais> TB_PONTOSMATERIAIS{get; set;}
        public DbSet<Pontuacao> TB_PONTUACAO{get; set;}
        public DbSet<Premios> TB_PREMIOS{get; set;}
        public DbSet<Publicacao> TB_PUBLICACAO{get; set;}
        public DbSet<TipoDePonto> TB_TIPOPONTO{get; set;}
        public DbSet<Trocas> TB_TROCAS{get; set;}

       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materiais>().ToTable("TB_MATERIAIS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Parceiros>().ToTable("TB_PARCEIROS");
            modelBuilder.Entity<Coletas>().ToTable("TB_COLETAS");
            modelBuilder.Entity<ColetaItens>().ToTable("TB_COLETAITENS");
            modelBuilder.Entity<Comentarios>().ToTable("TB_COMENTARIOS");
            modelBuilder.Entity<OrdemDeGrandeza>().ToTable("TB_ORDEMGRANDEZA");
            modelBuilder.Entity<Pontos>().ToTable("TB_PONTOS");
            modelBuilder.Entity<PontoseMateriais>().ToTable("TB_PONTOSMATERIAIS");
            modelBuilder.Entity<Pontuacao>().ToTable("TB_PONTUACAO");
            modelBuilder.Entity<Premios>().ToTable("TB_PREMIOS");
            modelBuilder.Entity<Publicacao>().ToTable("TB_PUBLICACAO");
            modelBuilder.Entity<TipoDePonto>().ToTable("TB_TIPOPONTO");
            modelBuilder.Entity<Trocas>().ToTable("TB_TROCAS");

            modelBuilder.Entity<Materiais>().HasKey(m => m.IdMaterial);
            modelBuilder.Entity<Usuario>().HasKey(m => m.IdUsuario);
            modelBuilder.Entity<Parceiros>().HasKey(m => m.IdParceiro);
            modelBuilder.Entity<Coletas>().HasKey(m => m.IdColeta);
            modelBuilder.Entity<ColetaItens>().HasKey(m => m.IdItemColeta);
            modelBuilder.Entity<Comentarios>().HasKey(m => m.IdComentario);
            modelBuilder.Entity<OrdemDeGrandeza>().HasKey(m => m.IdOrdemGrandeza);
            modelBuilder.Entity<Pontos>().HasKey(m => m.IdPonto);
            modelBuilder.Entity<PontoseMateriais>().HasNoKey();
            modelBuilder.Entity<Pontuacao>().HasNoKey();
            modelBuilder.Entity<Premios>().HasKey(m => m.IdPremio);
            modelBuilder.Entity<Publicacao>().HasKey(m => m.IdPublicacao);
            modelBuilder.Entity<TipoDePonto>().HasKey(m => m.IdTipoPonto);
            modelBuilder.Entity<Trocas>().HasKey(m => m.IdTroca);


            modelBuilder.Entity<Pontos>()
                .HasOne(e => e.TipoDePonto)
                .WithOne(e => e.Pontos)
                .HasForeignKey<TipoDePonto>(e => e.IdTipoPonto)
                .IsRequired();

                 

       modelBuilder.Entity<Materiais>().HasData
        (
            new Materiais() { IdMaterial = 1, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico},
            new Materiais() { IdMaterial = 2, NomeMaterial = "Papelão", Material=MateriaisEnun.Papel},
            new Materiais() { IdMaterial = 3, NomeMaterial = "Saco Plástico", Material=MateriaisEnun.Plastico},
            new Materiais() { IdMaterial = 4, NomeMaterial = "Lata de Feijoada", Material=MateriaisEnun.Metal},
            new Materiais() { IdMaterial = 5, NomeMaterial = "Latinha", Material=MateriaisEnun.Metal},
            new Materiais() { IdMaterial = 6, NomeMaterial = "Garrafa Pet", Material=MateriaisEnun.Plastico},      
            new Materiais() { IdMaterial = 7, NomeMaterial = "Jarra de Vidro", Material=MateriaisEnun.Vidro}
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
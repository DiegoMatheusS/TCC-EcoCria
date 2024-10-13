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
        public DbSet<ColetaItens> TB_COLETAITENS{get; set;}
        public DbSet<Coletas> TB_COLETAS{get; set;}
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
            modelBuilder.Entity<Pontuacao>().HasKey(m => m.IdPontuacao);
            modelBuilder.Entity<Premios>().HasKey(m => m.IdPremio);
            modelBuilder.Entity<Publicacao>().HasKey(m => m.IdPublicacao);
            modelBuilder.Entity<TipoDePonto>().HasKey(m => m.IdTipoPonto);
            modelBuilder.Entity<Trocas>().HasKey(m => m.IdTroca);


            modelBuilder.Entity<Pontos>()
                .HasOne(e => e.TipoPonto)
                .WithMany(e => e.Pontos)
                .HasForeignKey(e => e.IdTipoPonto)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Coletas>()
                .HasOne(e => e.Pontos)
                .WithMany(e => e.Coletas)
                .HasForeignKey(e => e.IdPonto);

            modelBuilder.Entity<Coletas>()
                .HasOne(e => e.Usuario)
                .WithMany(e => e.Coletas)
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Coletas>()
                .HasMany(e => e.ColetaItens)
                .WithOne(e => e.Coletas)
                .HasForeignKey(e => e.IdColeta)
                .OnDelete(DeleteBehavior.NoAction);

             modelBuilder.Entity<ColetaItens>()
                .HasOne(e => e.Materiais)
                .WithMany(e => e.ColetaItens)
                .HasForeignKey(e => e.IdMaterial);

            modelBuilder.Entity<ColetaItens>()
                .HasOne(e => e.OrdemDeGrandeza)
                .WithMany(e => e.ColetaItens)
                .HasForeignKey(e => e.IdOrdemGrandeza);
                



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
        modelBuilder.Entity<Comentarios>().HasData
        (
            new Comentarios() { IdComentario = 1, MomentoComentario=DateTime.Now, TextoComentario="Blabla"}
        );

        modelBuilder.Entity<Parceiros>().HasData
        (
            new Parceiros() { IdParceiro = 1, NomeParceiro = "Empresa BlaBla", DoacaoParceiro= 500},
            new Parceiros() { IdParceiro = 2, NomeParceiro = "Market Empresa", DoacaoParceiro= 500 },
            new Parceiros() { IdParceiro = 3, NomeParceiro = "Empresa Eletro", DoacaoParceiro= 500},
            new Parceiros() { IdParceiro = 4, NomeParceiro = "Empresa Papel", DoacaoParceiro= 500},
            new Parceiros() { IdParceiro = 5, NomeParceiro = "Empresa Rainiken", DoacaoParceiro= 500},
            new Parceiros() { IdParceiro = 6, NomeParceiro = "Empresa squol", DoacaoParceiro= 500},     
            new Parceiros() { IdParceiro = 7, NomeParceiro = "Empresa suifiti", DoacaoParceiro= 500} 
        );

        modelBuilder.Entity<ColetaItens>().HasData
        (
            new ColetaItens() { IdItemColeta = 1, QuantidadeColeta = 1},
            new ColetaItens() { IdItemColeta = 2, QuantidadeColeta = 2},
            new ColetaItens() { IdItemColeta = 3, QuantidadeColeta = 1},
            new ColetaItens() { IdItemColeta = 4, QuantidadeColeta = 2},
            new ColetaItens() { IdItemColeta = 5, QuantidadeColeta = 1},
            new ColetaItens() { IdItemColeta = 6, QuantidadeColeta = 2},   
            new ColetaItens() { IdItemColeta = 7, QuantidadeColeta = 1} 
        );

        modelBuilder.Entity<Coletas>().HasData
        (
            new Coletas() { IdColeta = 1, MomentoColeta = DateTime.Now},
            new Coletas() { IdColeta = 2, MomentoColeta = DateTime.Now},
            new Coletas() { IdColeta = 3, MomentoColeta = DateTime.Now},
            new Coletas() { IdColeta = 4, MomentoColeta = DateTime.Now},
            new Coletas() { IdColeta = 5, MomentoColeta = DateTime.Now},
            new Coletas() { IdColeta = 6, MomentoColeta = DateTime.Now},     
            new Coletas() { IdColeta = 7, MomentoColeta = DateTime.Now} 
        );

       
        modelBuilder.Entity<TipoDePonto>().HasData
        (
            new TipoDePonto() { IdTipoPonto = 1, DescricaoTipoPonto = "Ferro velho em geral", StatusTipoPonto=false},
            new TipoDePonto() { IdTipoPonto = 2, DescricaoTipoPonto = "Reciclagem", StatusTipoPonto=false},
            new TipoDePonto() { IdTipoPonto = 3, DescricaoTipoPonto = "Reciclagem em geral", StatusTipoPonto=false},
            new TipoDePonto() { IdTipoPonto = 4, DescricaoTipoPonto = "Ecoponto", StatusTipoPonto=false},
            new TipoDePonto() { IdTipoPonto = 5, DescricaoTipoPonto = "Recilagem de metais", StatusTipoPonto=false},
            new TipoDePonto() { IdTipoPonto = 6, DescricaoTipoPonto = "Recilcagem de papel e celulose", StatusTipoPonto=false},      
            new TipoDePonto() { IdTipoPonto = 7, DescricaoTipoPonto = "Recilcagem ", StatusTipoPonto=false}

        );
         modelBuilder.Entity<Pontos>().HasData
        (
            new Pontos() { IdPonto = 1, NomePonto = "São Quirino Sucatas", EnderecoPonto= "Rua São Quirino, 468 - Vila Guilherme", CepEndereco = 02056-070, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 1 },
            new Pontos() { IdPonto = 2, NomePonto = "Reciclagem, Sucatas e Aparas Farpec", EnderecoPonto= "R. Santa Clara, 350 - Brás", CepEndereco = 03025-030, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 2 },
            new Pontos() { IdPonto = 3, NomePonto = "Helio & Richard Reciclagem", EnderecoPonto= "R. Dr. Miguel Paulo Capalbo, 75 - Pari", CepEndereco = 03035-040, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 3 },
            new Pontos() { IdPonto = 4, NomePonto = "Ecoponto Vila Guilherme", EnderecoPonto= "Rua José Bernardo Pinto, 1480 - Vila Guilherme", CepEndereco = 02055-001, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 4 },
            new Pontos() { IdPonto = 5, NomePonto = "Latasa Reciclagem", EnderecoPonto= "Av. Guilherme Cotching, 726 - Vila Maria Baixa", CepEndereco = 02113-010, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 5 },
            new Pontos() { IdPonto = 6, NomePonto = "Ciclopel Com de Aparas de Papel", EnderecoPonto= "R. Henrique Felipe da Costa, 650 - Vila Guilherme", CepEndereco = 02054-050, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 6 },      
            new Pontos() { IdPonto = 7, NomePonto = "COLETATEC", EnderecoPonto= "R. Eli, 190 - Vila Maria Baixa", CepEndereco = 02114-010, CidadeEndereco = "São Paulo", UfEndereco = "SP",IdTipoPonto = 7 }
        );

          //inicio da criacao de usuário padrão
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

            modelBuilder.Entity<Usuario>().HasData(user); //fim da criacao do usuario padrao
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Cliente"); //Define que se o perfil nao for informado, o valor padrao sera jogador

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)//convensao para configurar a base, regras
        {
            configurationBuilder.Properties<string>().HaveColumnType("Varchar").HaveMaxLength(200);
        }

    }
}
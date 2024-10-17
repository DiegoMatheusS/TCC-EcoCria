﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCCEcoCria.Data;

#nullable disable

namespace ECOCRIA.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECOCRIA.Models.Contato", b =>
                {
                    b.Property<int>("IdContato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContato"));

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdContato");

                    b.ToTable("TB_CONTATO", (string)null);
                });

            modelBuilder.Entity("Models.ColetaItens", b =>
                {
                    b.Property<int>("IdItemColeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItemColeta"));

                    b.Property<int?>("IdColeta")
                        .HasColumnType("int");

                    b.Property<int?>("IdMaterial")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrdemGrandeza")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeColeta")
                        .HasColumnType("int");

                    b.HasKey("IdItemColeta");

                    b.HasIndex("IdColeta");

                    b.HasIndex("IdMaterial");

                    b.HasIndex("IdOrdemGrandeza");

                    b.ToTable("TB_COLETAITENS", (string)null);

                    b.HasData(
                        new
                        {
                            IdItemColeta = 1,
                            QuantidadeColeta = 1
                        },
                        new
                        {
                            IdItemColeta = 2,
                            QuantidadeColeta = 2
                        },
                        new
                        {
                            IdItemColeta = 3,
                            QuantidadeColeta = 1
                        },
                        new
                        {
                            IdItemColeta = 4,
                            QuantidadeColeta = 2
                        },
                        new
                        {
                            IdItemColeta = 5,
                            QuantidadeColeta = 1
                        },
                        new
                        {
                            IdItemColeta = 6,
                            QuantidadeColeta = 2
                        },
                        new
                        {
                            IdItemColeta = 7,
                            QuantidadeColeta = 1
                        });
                });

            modelBuilder.Entity("Models.Coletas", b =>
                {
                    b.Property<int>("IdColeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColeta"));

                    b.Property<int?>("IdPonto")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("MomentoColeta")
                        .HasColumnType("datetime2");

                    b.HasKey("IdColeta");

                    b.HasIndex("IdPonto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("TB_COLETAS", (string)null);

                    b.HasData(
                        new
                        {
                            IdColeta = 1,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9666)
                        },
                        new
                        {
                            IdColeta = 2,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9678)
                        },
                        new
                        {
                            IdColeta = 3,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9680)
                        },
                        new
                        {
                            IdColeta = 4,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9682)
                        },
                        new
                        {
                            IdColeta = 5,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9684)
                        },
                        new
                        {
                            IdColeta = 6,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9686)
                        },
                        new
                        {
                            IdColeta = 7,
                            MomentoColeta = new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9688)
                        });
                });

            modelBuilder.Entity("Models.Comentarios", b =>
                {
                    b.Property<int>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComentario"));

                    b.Property<DateTime>("MomentoComentario")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextoComentario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdComentario");

                    b.ToTable("TB_COMENTARIOS", (string)null);
                });

            modelBuilder.Entity("Models.Materiais", b =>
                {
                    b.Property<int>("IdMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaterial"));

                    b.Property<int>("IdOrdemGrandeza")
                        .HasColumnType("int");

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.Property<string>("NomeMaterial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int?>("OrdemDeGrandezaIdOrdemGrandeza")
                        .HasColumnType("int");

                    b.HasKey("IdMaterial");

                    b.HasIndex("OrdemDeGrandezaIdOrdemGrandeza");

                    b.ToTable("TB_MATERIAIS", (string)null);

                    b.HasData(
                        new
                        {
                            IdMaterial = 1,
                            IdOrdemGrandeza = 0,
                            Material = 1,
                            NomeMaterial = "Garrafa Pet"
                        },
                        new
                        {
                            IdMaterial = 2,
                            IdOrdemGrandeza = 0,
                            Material = 4,
                            NomeMaterial = "Papelão"
                        },
                        new
                        {
                            IdMaterial = 3,
                            IdOrdemGrandeza = 0,
                            Material = 1,
                            NomeMaterial = "Saco Plástico"
                        },
                        new
                        {
                            IdMaterial = 4,
                            IdOrdemGrandeza = 0,
                            Material = 2,
                            NomeMaterial = "Lata de Feijoada"
                        },
                        new
                        {
                            IdMaterial = 5,
                            IdOrdemGrandeza = 0,
                            Material = 2,
                            NomeMaterial = "Latinha"
                        },
                        new
                        {
                            IdMaterial = 6,
                            IdOrdemGrandeza = 0,
                            Material = 1,
                            NomeMaterial = "Garrafa Pet"
                        },
                        new
                        {
                            IdMaterial = 7,
                            IdOrdemGrandeza = 0,
                            Material = 3,
                            NomeMaterial = "Jarra de Vidro"
                        });
                });

            modelBuilder.Entity("Models.OrdemDeGrandeza", b =>
                {
                    b.Property<int>("IdOrdemGrandeza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrdemGrandeza"));

                    b.Property<string>("DescricaoOrdemGrandeza")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdOrdemGrandeza");

                    b.ToTable("TB_ORDEMGRANDEZA", (string)null);
                });

            modelBuilder.Entity("Models.Parceiros", b =>
                {
                    b.Property<int>("IdParceiro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdParceiro"));

                    b.Property<DateTime>("DataDoacao")
                        .HasColumnType("datetime2");

                    b.Property<double>("DoacaoParceiro")
                        .HasColumnType("float");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NomeParceiro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<bool>("StatusParceiro")
                        .HasColumnType("bit");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdParceiro");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("TB_PARCEIROS", (string)null);

                    b.HasData(
                        new
                        {
                            IdParceiro = 1,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Empresa BlaBla",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 2,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Market Empresa",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 3,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Empresa Eletro",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 4,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Empresa Papel",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 5,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Empresa Rainiken",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 6,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Empresa squol",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 7,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            NomeParceiro = "Empresa suifiti",
                            StatusParceiro = false
                        });
                });

            modelBuilder.Entity("Models.Pontos", b =>
                {
                    b.Property<int>("IdPonto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPonto"));

                    b.Property<int>("CepEndereco")
                        .HasColumnType("int");

                    b.Property<string>("CidadeEndereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("EnderecoPonto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int?>("IdTipoPonto")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NomePonto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("UfEndereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdPonto");

                    b.HasIndex("IdTipoPonto");

                    b.ToTable("TB_PONTOS", (string)null);

                    b.HasData(
                        new
                        {
                            IdPonto = 1,
                            CepEndereco = 1986,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "Rua São Quirino, 468 - Vila Guilherme",
                            IdTipoPonto = 1,
                            NomePonto = "São Quirino Sucatas",
                            UfEndereco = "SP"
                        },
                        new
                        {
                            IdPonto = 2,
                            CepEndereco = 2995,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "R. Santa Clara, 350 - Brás",
                            IdTipoPonto = 2,
                            NomePonto = "Reciclagem, Sucatas e Aparas Farpec",
                            UfEndereco = "SP"
                        },
                        new
                        {
                            IdPonto = 3,
                            CepEndereco = 2995,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "R. Dr. Miguel Paulo Capalbo, 75 - Pari",
                            IdTipoPonto = 3,
                            NomePonto = "Helio & Richard Reciclagem",
                            UfEndereco = "SP"
                        },
                        new
                        {
                            IdPonto = 4,
                            CepEndereco = 2054,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "Rua José Bernardo Pinto, 1480 - Vila Guilherme",
                            IdTipoPonto = 4,
                            NomePonto = "Ecoponto Vila Guilherme",
                            UfEndereco = "SP"
                        },
                        new
                        {
                            IdPonto = 5,
                            CepEndereco = 2103,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "Av. Guilherme Cotching, 726 - Vila Maria Baixa",
                            IdTipoPonto = 5,
                            NomePonto = "Latasa Reciclagem",
                            UfEndereco = "SP"
                        },
                        new
                        {
                            IdPonto = 6,
                            CepEndereco = 2004,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "R. Henrique Felipe da Costa, 650 - Vila Guilherme",
                            IdTipoPonto = 6,
                            NomePonto = "Ciclopel Com de Aparas de Papel",
                            UfEndereco = "SP"
                        },
                        new
                        {
                            IdPonto = 7,
                            CepEndereco = 2104,
                            CidadeEndereco = "São Paulo",
                            EnderecoPonto = "R. Eli, 190 - Vila Maria Baixa",
                            IdTipoPonto = 7,
                            NomePonto = "COLETATEC",
                            UfEndereco = "SP"
                        });
                });

            modelBuilder.Entity("Models.PontoseMateriais", b =>
                {
                    b.Property<string>("DescricaoPontomaterial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int>("IdMaterial")
                        .HasColumnType("int");

                    b.Property<int>("IdPonto")
                        .HasColumnType("int");

                    b.Property<int>("IdPontoMaterial")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaisIdMaterial")
                        .HasColumnType("int");

                    b.Property<int?>("PontosIdPonto")
                        .HasColumnType("int");

                    b.Property<bool>("StatusPontoMaterial")
                        .HasColumnType("bit");

                    b.HasIndex("MateriaisIdMaterial");

                    b.HasIndex("PontosIdPonto");

                    b.ToTable("TB_PONTOSMATERIAIS", (string)null);
                });

            modelBuilder.Entity("Models.Pontuacao", b =>
                {
                    b.Property<int>("IdPontuacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPontuacao"));

                    b.Property<int?>("ColetasIdColeta")
                        .HasColumnType("int");

                    b.Property<int?>("IdColeta")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadePontos")
                        .HasColumnType("int");

                    b.Property<bool>("StatusPontos")
                        .HasColumnType("bit");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPontuacao");

                    b.HasIndex("ColetasIdColeta");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("TB_PONTUACAO", (string)null);
                });

            modelBuilder.Entity("Models.Premios", b =>
                {
                    b.Property<int>("IdPremio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPremio"));

                    b.Property<string>("DescricaoPremio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int>("PontosPremio")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadePremio")
                        .HasColumnType("int");

                    b.HasKey("IdPremio");

                    b.ToTable("TB_PREMIOS", (string)null);
                });

            modelBuilder.Entity("Models.Publicacao", b =>
                {
                    b.Property<int>("IdPublicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacao"));

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextoPublicacao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("TituloPublicacao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdPublicacao");

                    b.ToTable("TB_PUBLICACAO", (string)null);
                });

            modelBuilder.Entity("Models.TipoDePonto", b =>
                {
                    b.Property<int>("IdTipoPonto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoPonto"));

                    b.Property<string>("DescricaoTipoPonto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<bool>("StatusTipoPonto")
                        .HasColumnType("bit");

                    b.HasKey("IdTipoPonto");

                    b.ToTable("TB_TIPOPONTO", (string)null);

                    b.HasData(
                        new
                        {
                            IdTipoPonto = 1,
                            DescricaoTipoPonto = "Ferro velho em geral",
                            StatusTipoPonto = false
                        },
                        new
                        {
                            IdTipoPonto = 2,
                            DescricaoTipoPonto = "Reciclagem",
                            StatusTipoPonto = false
                        },
                        new
                        {
                            IdTipoPonto = 3,
                            DescricaoTipoPonto = "Reciclagem em geral",
                            StatusTipoPonto = false
                        },
                        new
                        {
                            IdTipoPonto = 4,
                            DescricaoTipoPonto = "Ecoponto",
                            StatusTipoPonto = false
                        },
                        new
                        {
                            IdTipoPonto = 5,
                            DescricaoTipoPonto = "Recilagem de metais",
                            StatusTipoPonto = false
                        },
                        new
                        {
                            IdTipoPonto = 6,
                            DescricaoTipoPonto = "Recilcagem de papel e celulose",
                            StatusTipoPonto = false
                        },
                        new
                        {
                            IdTipoPonto = 7,
                            DescricaoTipoPonto = "Recilcagem ",
                            StatusTipoPonto = false
                        });
                });

            modelBuilder.Entity("Models.TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoUsuario"));

                    b.Property<string>("DescricaoTipoUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdTipoUsuario");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("TB_TIPOUSUARIO", (string)null);
                });

            modelBuilder.Entity("Models.Trocas", b =>
                {
                    b.Property<int>("IdTroca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTroca"));

                    b.Property<DateTime>("MomentoTroca")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTroca");

                    b.ToTable("TB_TROCAS", (string)null);
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<byte[]>("FotoUsuario")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar")
                        .HasDefaultValue("Cliente");

                    b.HasKey("IdUsuario");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            EmailUsuario = "seuEmail@gmail.com",
                            Latitude = -23.520024100000001,
                            Longitude = -46.596497999999997,
                            NomeUsuario = "admin",
                            PasswordHash = new byte[] { 146, 74, 245, 131, 15, 237, 1, 92, 40, 90, 14, 32, 167, 77, 65, 82, 233, 129, 32, 44, 217, 129, 54, 207, 4, 250, 159, 224, 48, 37, 161, 160, 67, 22, 209, 171, 64, 82, 177, 164, 82, 5, 32, 208, 191, 244, 171, 214, 201, 12, 127, 197, 93, 135, 202, 85, 254, 131, 174, 154, 32, 70, 188, 209, 0, 190, 135, 131, 242, 222, 93, 44, 165, 75, 160, 252, 40, 37, 151, 103, 64, 41, 226, 8, 245, 150, 226, 121, 135, 207, 158, 210, 215, 41, 125, 176, 159, 66, 227, 177, 214, 228, 168, 64, 197, 85, 49, 101, 109, 172, 32, 72, 46, 228, 27, 229, 14, 238, 244, 232, 234, 104, 169, 184, 226, 91, 213, 162 },
                            Perfil = "Admin"
                        });
                });

            modelBuilder.Entity("Models.ColetaItens", b =>
                {
                    b.HasOne("Models.Coletas", "Coletas")
                        .WithMany("ColetaItens")
                        .HasForeignKey("IdColeta")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Models.Materiais", "Materiais")
                        .WithMany("ColetaItens")
                        .HasForeignKey("IdMaterial");

                    b.HasOne("Models.OrdemDeGrandeza", "OrdemDeGrandeza")
                        .WithMany("ColetaItens")
                        .HasForeignKey("IdOrdemGrandeza");

                    b.Navigation("Coletas");

                    b.Navigation("Materiais");

                    b.Navigation("OrdemDeGrandeza");
                });

            modelBuilder.Entity("Models.Coletas", b =>
                {
                    b.HasOne("Models.Pontos", "Pontos")
                        .WithMany("Coletas")
                        .HasForeignKey("IdPonto");

                    b.HasOne("Models.Usuario", "Usuario")
                        .WithMany("Coletas")
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Pontos");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Models.Materiais", b =>
                {
                    b.HasOne("Models.OrdemDeGrandeza", "OrdemDeGrandeza")
                        .WithMany()
                        .HasForeignKey("OrdemDeGrandezaIdOrdemGrandeza");

                    b.Navigation("OrdemDeGrandeza");
                });

            modelBuilder.Entity("Models.Parceiros", b =>
                {
                    b.HasOne("Models.Usuario", "Usuario")
                        .WithMany("Parceiros")
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Models.Pontos", b =>
                {
                    b.HasOne("Models.TipoDePonto", "TipoDePonto")
                        .WithMany("Pontos")
                        .HasForeignKey("IdTipoPonto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDePonto");
                });

            modelBuilder.Entity("Models.PontoseMateriais", b =>
                {
                    b.HasOne("Models.Materiais", "Materiais")
                        .WithMany()
                        .HasForeignKey("MateriaisIdMaterial");

                    b.HasOne("Models.Pontos", "Pontos")
                        .WithMany()
                        .HasForeignKey("PontosIdPonto");

                    b.Navigation("Materiais");

                    b.Navigation("Pontos");
                });

            modelBuilder.Entity("Models.Pontuacao", b =>
                {
                    b.HasOne("Models.Coletas", "Coletas")
                        .WithMany()
                        .HasForeignKey("ColetasIdColeta");

                    b.HasOne("Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Coletas");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Models.TipoUsuario", b =>
                {
                    b.HasOne("Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Models.Coletas", b =>
                {
                    b.Navigation("ColetaItens");
                });

            modelBuilder.Entity("Models.Materiais", b =>
                {
                    b.Navigation("ColetaItens");
                });

            modelBuilder.Entity("Models.OrdemDeGrandeza", b =>
                {
                    b.Navigation("ColetaItens");
                });

            modelBuilder.Entity("Models.Pontos", b =>
                {
                    b.Navigation("Coletas");
                });

            modelBuilder.Entity("Models.TipoDePonto", b =>
                {
                    b.Navigation("Pontos");
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Navigation("Coletas");

                    b.Navigation("Parceiros");
                });
#pragma warning restore 612, 618
        }
    }
}

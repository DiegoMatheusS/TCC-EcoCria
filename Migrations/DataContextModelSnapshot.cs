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

            modelBuilder.Entity("Models.ColetaItens", b =>
                {
                    b.Property<int>("IdItemColeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItemColeta"));

                    b.Property<int>("QuantidadeColeta")
                        .HasColumnType("int");

                    b.HasKey("IdItemColeta");

                    b.ToTable("TB_COLETAITENS", (string)null);
                });

            modelBuilder.Entity("Models.Coletas", b =>
                {
                    b.Property<int>("IdColeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColeta"));

                    b.Property<DateTime>("MomentoColeta")
                        .HasColumnType("datetime2");

                    b.HasKey("IdColeta");

                    b.ToTable("TB_COLETAS", (string)null);
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

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.Property<string>("NomeMaterial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdMaterial");

                    b.ToTable("TB_MATERIAIS", (string)null);

                    b.HasData(
                        new
                        {
                            IdMaterial = 1,
                            Material = 1,
                            NomeMaterial = "Garrafa Pet"
                        },
                        new
                        {
                            IdMaterial = 2,
                            Material = 4,
                            NomeMaterial = "Papelão"
                        },
                        new
                        {
                            IdMaterial = 3,
                            Material = 1,
                            NomeMaterial = "Saco Plástico"
                        },
                        new
                        {
                            IdMaterial = 4,
                            Material = 2,
                            NomeMaterial = "Lata de Feijoada"
                        },
                        new
                        {
                            IdMaterial = 5,
                            Material = 2,
                            NomeMaterial = "Latinha"
                        },
                        new
                        {
                            IdMaterial = 6,
                            Material = 1,
                            NomeMaterial = "Garrafa Pet"
                        },
                        new
                        {
                            IdMaterial = 7,
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
                            IdUsuario = 1,
                            NomeParceiro = "Empresa BlaBla",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 2,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            IdUsuario = 2,
                            NomeParceiro = "Market Empresa",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 3,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            IdUsuario = 3,
                            NomeParceiro = "Empresa Eletro",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 4,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            IdUsuario = 4,
                            NomeParceiro = "Empresa Papel",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 5,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            IdUsuario = 5,
                            NomeParceiro = "Empresa Rainiken",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 6,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            IdUsuario = 6,
                            NomeParceiro = "Empresa squol",
                            StatusParceiro = false
                        },
                        new
                        {
                            IdParceiro = 7,
                            DataDoacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoacaoParceiro = 500.0,
                            IdUsuario = 7,
                            NomeParceiro = "Empresa suifiti",
                            StatusParceiro = false
                        });
                });

            modelBuilder.Entity("Models.Pontos", b =>
                {
                    b.Property<int>("IdPonto")
                        .HasColumnType("int");

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

                    b.Property<string>("NomePonto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<string>("UfEndereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.HasKey("IdPonto");

                    b.ToTable("TB_PONTOS", (string)null);
                });

            modelBuilder.Entity("Models.PontoseMateriais", b =>
                {
                    b.Property<string>("DescricaoPontomaterial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar");

                    b.Property<bool>("StatusPontoMaterial")
                        .HasColumnType("bit");

                    b.ToTable("TB_PONTOSMATERIAIS", (string)null);
                });

            modelBuilder.Entity("Models.Pontuacao", b =>
                {
                    b.Property<int>("QuantidadePontos")
                        .HasColumnType("int");

                    b.Property<bool>("StatusPontos")
                        .HasColumnType("bit");

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

                    b.Property<int>("IdPonto")
                        .HasColumnType("int");

                    b.Property<bool>("StatusTipoPonto")
                        .HasColumnType("bit");

                    b.HasKey("IdTipoPonto");

                    b.ToTable("TB_TIPOPONTO", (string)null);
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
                            PasswordHash = new byte[] { 93, 178, 207, 244, 151, 242, 194, 132, 187, 137, 114, 201, 129, 32, 27, 12, 20, 115, 93, 45, 188, 131, 71, 230, 123, 98, 79, 51, 218, 154, 147, 155, 145, 236, 23, 150, 91, 73, 161, 136, 207, 241, 59, 41, 116, 155, 145, 101, 151, 93, 97, 225, 31, 145, 43, 120, 128, 161, 246, 184, 9, 188, 112, 24, 64, 40, 97, 84, 239, 236, 104, 142, 6, 199, 144, 204, 249, 78, 246, 237, 93, 209, 227, 8, 132, 52, 152, 104, 52, 137, 32, 249, 109, 48, 124, 223, 48, 39, 61, 211, 186, 169, 190, 230, 25, 228, 246, 253, 227, 246, 91, 26, 155, 55, 141, 9, 255, 189, 135, 67, 231, 83, 229, 13, 253, 203, 167, 219 },
                            Perfil = "Admin"
                        });
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
                        .WithOne("Pontos")
                        .HasForeignKey("Models.Pontos", "IdPonto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDePonto");
                });

            modelBuilder.Entity("Models.TipoDePonto", b =>
                {
                    b.Navigation("Pontos")
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Navigation("Parceiros");
                });
#pragma warning restore 612, 618
        }
    }
}

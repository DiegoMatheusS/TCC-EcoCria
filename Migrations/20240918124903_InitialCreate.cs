using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_COLETAITENS",
                columns: table => new
                {
                    IdItemColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeColeta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COLETAITENS", x => x.IdItemColeta);
                });

            migrationBuilder.CreateTable(
                name: "TB_COLETAS",
                columns: table => new
                {
                    IdColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MomentoColeta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COLETAS", x => x.IdColeta);
                });

            migrationBuilder.CreateTable(
                name: "TB_COMENTARIOS",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MomentoComentario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextoComentario = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMENTARIOS", x => x.IdComentario);
                });

            migrationBuilder.CreateTable(
                name: "TB_MATERIAIS",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMaterial = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MATERIAIS", x => x.IdMaterial);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDEMGRANDEZA",
                columns: table => new
                {
                    IdOrdemGrandeza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoOrdemGrandeza = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDEMGRANDEZA", x => x.IdOrdemGrandeza);
                });

            migrationBuilder.CreateTable(
                name: "TB_PONTOSMATERIAIS",
                columns: table => new
                {
                    DescricaoPontomaterial = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    StatusPontoMaterial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TB_PONTUACAO",
                columns: table => new
                {
                    QuantidadePontos = table.Column<int>(type: "int", nullable: false),
                    StatusPontos = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TB_PREMIOS",
                columns: table => new
                {
                    IdPremio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoPremio = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    QuantidadePremio = table.Column<int>(type: "int", nullable: false),
                    PontosPremio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PREMIOS", x => x.IdPremio);
                });

            migrationBuilder.CreateTable(
                name: "TB_PUBLICACAO",
                columns: table => new
                {
                    IdPublicacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TituloPublicacao = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    TextoPublicacao = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PUBLICACAO", x => x.IdPublicacao);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPOPONTO",
                columns: table => new
                {
                    IdTipoPonto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTipoPonto = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    StatusTipoPonto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPOPONTO", x => x.IdTipoPonto);
                });

            migrationBuilder.CreateTable(
                name: "TB_TROCAS",
                columns: table => new
                {
                    IdTroca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MomentoTroca = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TROCAS", x => x.IdTroca);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Perfil = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false, defaultValue: "Cliente"),
                    EmailUsuario = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "TB_PONTOS",
                columns: table => new
                {
                    IdPonto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePonto = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    EnderecoPonto = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    CepEndereco = table.Column<int>(type: "int", nullable: false),
                    UfEndereco = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    CidadeEndereco = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    IdTipoPonto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PONTOS", x => x.IdPonto);
                    table.ForeignKey(
                        name: "FK_TB_PONTOS_TB_TIPOPONTO_IdTipoPonto",
                        column: x => x.IdTipoPonto,
                        principalTable: "TB_TIPOPONTO",
                        principalColumn: "IdTipoPonto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PARCEIROS",
                columns: table => new
                {
                    IdParceiro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeParceiro = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    StatusParceiro = table.Column<bool>(type: "bit", nullable: false),
                    DoacaoParceiro = table.Column<double>(type: "float", nullable: false),
                    DataDoacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PARCEIROS", x => x.IdParceiro);
                    table.ForeignKey(
                        name: "FK_TB_PARCEIROS_TB_USUARIOS_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "IdUsuario", "DataAcesso", "EmailUsuario", "Latitude", "Longitude", "NomeUsuario", "PasswordHash", "PasswordSalt", "Perfil" },
                values: new object[] { 1, null, "seuEmail@gmail.com", -23.520024100000001, -46.596497999999997, "admin", new byte[] { 196, 140, 239, 78, 249, 216, 186, 51, 112, 152, 153, 136, 73, 138, 230, 250, 218, 165, 80, 116, 192, 105, 183, 148, 75, 64, 149, 158, 36, 125, 145, 212, 84, 128, 174, 168, 97, 75, 113, 213, 225, 248, 181, 122, 185, 105, 156, 166, 149, 200, 162, 154, 208, 247, 160, 86, 194, 47, 40, 203, 192, 176, 96, 156, 196, 209, 255, 12, 202, 127, 21, 175, 124, 208, 168, 201, 30, 141, 166, 220, 211, 162, 170, 188, 25, 187, 252, 79, 146, 139, 145, 45, 48, 76, 1, 226, 180, 110, 198, 157, 165, 231, 140, 146, 217, 54, 95, 22, 5, 199, 221, 251, 247, 17, 188, 246, 64, 20, 41, 119, 89, 233, 13, 139, 125, 192, 147, 61 }, null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARCEIROS_UsuarioIdUsuario",
                table: "TB_PARCEIROS",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTOS_IdTipoPonto",
                table: "TB_PONTOS",
                column: "IdTipoPonto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_COLETAITENS");

            migrationBuilder.DropTable(
                name: "TB_COLETAS");

            migrationBuilder.DropTable(
                name: "TB_COMENTARIOS");

            migrationBuilder.DropTable(
                name: "TB_MATERIAIS");

            migrationBuilder.DropTable(
                name: "TB_ORDEMGRANDEZA");

            migrationBuilder.DropTable(
                name: "TB_PARCEIROS");

            migrationBuilder.DropTable(
                name: "TB_PONTOS");

            migrationBuilder.DropTable(
                name: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropTable(
                name: "TB_PONTUACAO");

            migrationBuilder.DropTable(
                name: "TB_PREMIOS");

            migrationBuilder.DropTable(
                name: "TB_PUBLICACAO");

            migrationBuilder.DropTable(
                name: "TB_TROCAS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_TIPOPONTO");
        }
    }
}

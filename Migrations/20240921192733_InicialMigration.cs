using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
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
                name: "TB_TIPOPONTO",
                columns: table => new
                {
                    IdTipoPonto = table.Column<int>(type: "int", nullable: false),
                    DescricaoTipoPonto = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    StatusTipoPonto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPOPONTO", x => x.IdTipoPonto);
                    table.ForeignKey(
                        name: "FK_TB_TIPOPONTO_TB_PONTOS_IdTipoPonto",
                        column: x => x.IdTipoPonto,
                        principalTable: "TB_PONTOS",
                        principalColumn: "IdPonto",
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
                table: "TB_MATERIAIS",
                columns: new[] { "IdMaterial", "Material", "NomeMaterial" },
                values: new object[,]
                {
                    { 1, 1, "Garrafa Pet" },
                    { 2, 4, "Papelão" },
                    { 3, 1, "Saco Plástico" },
                    { 4, 2, "Lata de Feijoada" },
                    { 5, 2, "Latinha" },
                    { 6, 1, "Garrafa Pet" },
                    { 7, 3, "Jarra de Vidro" }
                });

            migrationBuilder.InsertData(
                table: "TB_PARCEIROS",
                columns: new[] { "IdParceiro", "DataDoacao", "DoacaoParceiro", "IdUsuario", "NomeParceiro", "StatusParceiro", "UsuarioIdUsuario" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 1, "Empresa BlaBla", false, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 2, "Market Empresa", false, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 3, "Empresa Eletro", false, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 4, "Empresa Papel", false, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 5, "Empresa Rainiken", false, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 6, "Empresa squol", false, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0, 7, "Empresa suifiti", false, null }
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "IdUsuario", "DataAcesso", "EmailUsuario", "Latitude", "Longitude", "NomeUsuario", "PasswordHash", "PasswordSalt", "Perfil" },
                values: new object[] { 1, null, "seuEmail@gmail.com", -23.520024100000001, -46.596497999999997, "admin", new byte[] { 235, 218, 148, 20, 120, 115, 104, 20, 108, 118, 251, 148, 117, 226, 74, 125, 55, 226, 39, 200, 160, 135, 195, 3, 197, 44, 148, 165, 82, 243, 102, 53, 31, 172, 26, 143, 151, 25, 75, 234, 47, 176, 37, 8, 116, 163, 58, 15, 13, 195, 237, 30, 38, 167, 89, 59, 24, 132, 32, 79, 69, 148, 232, 110, 87, 132, 221, 19, 46, 210, 41, 28, 171, 62, 15, 119, 232, 51, 19, 68, 134, 233, 131, 123, 208, 9, 183, 216, 85, 183, 140, 144, 202, 194, 121, 28, 196, 197, 219, 225, 236, 1, 151, 224, 245, 210, 177, 127, 126, 5, 124, 181, 39, 184, 168, 177, 5, 78, 209, 120, 69, 104, 37, 115, 41, 12, 62, 116 }, null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARCEIROS_UsuarioIdUsuario",
                table: "TB_PARCEIROS",
                column: "UsuarioIdUsuario");
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
                name: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropTable(
                name: "TB_PONTUACAO");

            migrationBuilder.DropTable(
                name: "TB_PREMIOS");

            migrationBuilder.DropTable(
                name: "TB_PUBLICACAO");

            migrationBuilder.DropTable(
                name: "TB_TIPOPONTO");

            migrationBuilder.DropTable(
                name: "TB_TROCAS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_PONTOS");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TB_COLETAS",
                columns: table => new
                {
                    IdColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MomentoColeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPonto = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COLETAS", x => x.IdColeta);
                    table.ForeignKey(
                        name: "FK_TB_COLETAS_TB_PONTOS_IdPonto",
                        column: x => x.IdPonto,
                        principalTable: "TB_PONTOS",
                        principalColumn: "IdPonto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_COLETAS_TB_USUARIOS_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_COLETAITENS",
                columns: table => new
                {
                    IdItemColeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeColeta = table.Column<int>(type: "int", nullable: false),
                    IdColeta = table.Column<int>(type: "int", nullable: true),
                    IdMaterial = table.Column<int>(type: "int", nullable: true),
                    IdOrdemGrandeza = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COLETAITENS", x => x.IdItemColeta);
                    table.ForeignKey(
                        name: "FK_TB_COLETAITENS_TB_COLETAS_IdColeta",
                        column: x => x.IdColeta,
                        principalTable: "TB_COLETAS",
                        principalColumn: "IdColeta");
                    table.ForeignKey(
                        name: "FK_TB_COLETAITENS_TB_MATERIAIS_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "TB_MATERIAIS",
                        principalColumn: "IdMaterial");
                    table.ForeignKey(
                        name: "FK_TB_COLETAITENS_TB_ORDEMGRANDEZA_IdOrdemGrandeza",
                        column: x => x.IdOrdemGrandeza,
                        principalTable: "TB_ORDEMGRANDEZA",
                        principalColumn: "IdOrdemGrandeza");
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
                table: "TB_TIPOPONTO",
                columns: new[] { "IdTipoPonto", "DescricaoTipoPonto", "StatusTipoPonto" },
                values: new object[,]
                {
                    { 1, "Ferro velho em geral", false },
                    { 2, "Reciclagem", false },
                    { 3, "Reciclagem em geral", false },
                    { 4, "Ecoponto", false },
                    { 5, "Recilagem de metais", false },
                    { 6, "Recilcagem de papel e celulose", false },
                    { 7, "Recilcagem ", false }
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "IdUsuario", "DataAcesso", "EmailUsuario", "Latitude", "Longitude", "NomeUsuario", "PasswordHash", "PasswordSalt", "Perfil" },
                values: new object[] { 1, null, "seuEmail@gmail.com", -23.520024100000001, -46.596497999999997, "admin", new byte[] { 20, 190, 192, 164, 116, 57, 158, 84, 28, 110, 5, 149, 229, 73, 166, 220, 60, 74, 58, 93, 224, 0, 127, 211, 180, 59, 114, 247, 104, 97, 181, 116, 38, 235, 69, 159, 66, 216, 129, 74, 131, 206, 136, 76, 236, 251, 114, 236, 41, 20, 62, 235, 81, 29, 222, 188, 142, 231, 199, 67, 20, 50, 80, 200, 96, 208, 11, 97, 43, 78, 144, 249, 250, 35, 28, 115, 209, 162, 128, 127, 77, 255, 204, 242, 245, 90, 133, 244, 221, 156, 18, 78, 10, 20, 214, 39, 91, 82, 176, 118, 221, 25, 155, 79, 148, 169, 108, 9, 211, 26, 12, 120, 249, 70, 238, 97, 240, 75, 208, 207, 136, 113, 58, 50, 86, 66, 221, 151 }, null, "Admin" });

            migrationBuilder.InsertData(
                table: "TB_PONTOS",
                columns: new[] { "IdPonto", "CepEndereco", "CidadeEndereco", "EnderecoPonto", "IdTipoPonto", "NomePonto", "UfEndereco" },
                values: new object[,]
                {
                    { 1, 1986, "São Paulo", "Rua São Quirino, 468 - Vila Guilherme", 1, "São Quirino Sucatas", "SP" },
                    { 2, 2995, "São Paulo", "R. Santa Clara, 350 - Brás", 2, "Reciclagem, Sucatas e Aparas Farpec", "SP" },
                    { 3, 2995, "São Paulo", "R. Dr. Miguel Paulo Capalbo, 75 - Pari", 3, "Helio & Richard Reciclagem", "SP" },
                    { 4, 2054, "São Paulo", "Rua José Bernardo Pinto, 1480 - Vila Guilherme", 4, "Ecoponto Vila Guilherme", "SP" },
                    { 5, 2103, "São Paulo", "Av. Guilherme Cotching, 726 - Vila Maria Baixa", 5, "Latasa Reciclagem", "SP" },
                    { 6, 2004, "São Paulo", "R. Henrique Felipe da Costa, 650 - Vila Guilherme", 6, "Ciclopel Com de Aparas de Papel", "SP" },
                    { 7, 2104, "São Paulo", "R. Eli, 190 - Vila Maria Baixa", 7, "COLETATEC", "SP" }
                });

            migrationBuilder.InsertData(
                table: "TB_COLETAS",
                columns: new[] { "IdColeta", "IdPonto", "IdUsuario", "MomentoColeta" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7880) },
                    { 2, 2, 2, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7897) },
                    { 3, 3, 3, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7899) },
                    { 4, 4, 4, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7901) },
                    { 5, 5, 5, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7903) },
                    { 6, 6, 6, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7905) },
                    { 7, 7, 7, new DateTime(2024, 9, 19, 15, 15, 15, 268, DateTimeKind.Local).AddTicks(7907) }
                });

            migrationBuilder.InsertData(
                table: "TB_COLETAITENS",
                columns: new[] { "IdItemColeta", "IdColeta", "IdMaterial", "IdOrdemGrandeza", "QuantidadeColeta" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 2, 2, 2, 2 },
                    { 3, 3, 3, 3, 1 },
                    { 4, 4, 4, 4, 2 },
                    { 5, 5, 51, 5, 1 },
                    { 6, 6, 6, 6, 2 },
                    { 7, 7, 7, 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_COLETAITENS_IdColeta",
                table: "TB_COLETAITENS",
                column: "IdColeta");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COLETAITENS_IdMaterial",
                table: "TB_COLETAITENS",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COLETAITENS_IdOrdemGrandeza",
                table: "TB_COLETAITENS",
                column: "IdOrdemGrandeza");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COLETAS_IdPonto",
                table: "TB_COLETAS",
                column: "IdPonto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COLETAS_IdUsuario",
                table: "TB_COLETAS",
                column: "IdUsuario");

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
                name: "TB_COMENTARIOS");

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
                name: "TB_TROCAS");

            migrationBuilder.DropTable(
                name: "TB_COLETAS");

            migrationBuilder.DropTable(
                name: "TB_MATERIAIS");

            migrationBuilder.DropTable(
                name: "TB_ORDEMGRANDEZA");

            migrationBuilder.DropTable(
                name: "TB_PONTOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_TIPOPONTO");
        }
    }
}

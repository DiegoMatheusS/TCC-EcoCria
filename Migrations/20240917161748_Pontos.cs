using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class Pontos : Migration
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
                    CidadeEndereco = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
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

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 58, 21, 63, 103, 119, 209, 30, 120, 56, 64, 9, 101, 232, 111, 116, 120, 60, 102, 242, 31, 9, 145, 4, 43, 107, 243, 116, 236, 227, 210, 48, 53, 252, 61, 81, 76, 167, 206, 214, 120, 236, 32, 204, 150, 41, 101, 221, 51, 214, 31, 50, 254, 134, 136, 241, 76, 31, 40, 138, 51, 177, 90, 22, 187, 218, 32, 59, 28, 77, 14, 81, 50, 74, 153, 138, 33, 228, 238, 156, 124, 211, 192, 15, 18, 70, 219, 8, 157, 227, 75, 6, 1, 57, 86, 161, 23, 236, 152, 139, 173, 125, 65, 202, 233, 37, 120, 252, 37, 151, 230, 229, 87, 18, 116, 39, 204, 101, 105, 52, 29, 167, 142, 117, 63, 61, 58, 102, 138 });
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
                name: "TB_ORDEMGRANDEZA");

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
                name: "TB_TIPOPONTO");

            migrationBuilder.DropTable(
                name: "TB_TROCAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 233, 212, 81, 184, 27, 82, 133, 230, 117, 217, 16, 70, 250, 82, 24, 122, 30, 226, 215, 235, 174, 125, 238, 198, 157, 18, 165, 78, 143, 44, 239, 190, 21, 216, 198, 120, 15, 107, 186, 24, 149, 109, 53, 16, 6, 34, 254, 10, 153, 87, 30, 95, 212, 207, 202, 133, 231, 178, 47, 116, 199, 188, 208, 2, 140, 4, 76, 238, 13, 19, 153, 101, 93, 226, 250, 162, 254, 67, 73, 243, 86, 224, 98, 185, 173, 247, 78, 49, 74, 244, 206, 129, 103, 154, 189, 198, 197, 91, 111, 98, 132, 62, 6, 104, 203, 254, 37, 194, 166, 210, 152, 115, 13, 32, 203, 129, 165, 20, 101, 5, 45, 176, 134, 75, 174, 30, 239, 172 });
        }
    }
}

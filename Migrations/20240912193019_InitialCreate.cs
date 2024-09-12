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
                values: new object[] { 1, null, "seuEmail@gmail.com", -23.520024100000001, -46.596497999999997, "admin", new byte[] { 233, 212, 81, 184, 27, 82, 133, 230, 117, 217, 16, 70, 250, 82, 24, 122, 30, 226, 215, 235, 174, 125, 238, 198, 157, 18, 165, 78, 143, 44, 239, 190, 21, 216, 198, 120, 15, 107, 186, 24, 149, 109, 53, 16, 6, 34, 254, 10, 153, 87, 30, 95, 212, 207, 202, 133, 231, 178, 47, 116, 199, 188, 208, 2, 140, 4, 76, 238, 13, 19, 153, 101, 93, 226, 250, 162, 254, 67, 73, 243, 86, 224, 98, 185, 173, 247, 78, 49, 74, 244, 206, 129, 103, 154, 189, 198, 197, 91, 111, 98, 132, 62, 6, 104, 203, 254, 37, 194, 166, 210, 152, 115, 13, 32, 203, 129, 165, 20, 101, 5, 45, 176, 134, 75, 174, 30, 239, 172 }, null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARCEIROS_UsuarioIdUsuario",
                table: "TB_PARCEIROS",
                column: "UsuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MATERIAIS");

            migrationBuilder.DropTable(
                name: "TB_PARCEIROS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUsuario",
                table: "TB_USUARIOS");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRecuperacao",
                table: "TB_USUARIOS",
                type: "Varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCodigoExpiracao",
                table: "TB_USUARIOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 11, 26, 16, 37, 8, 300, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "CodigoRecuperacao", "DataCodigoExpiracao", "PasswordHash" },
                values: new object[] { "", null, new byte[] { 154, 249, 225, 145, 95, 247, 8, 173, 255, 243, 181, 237, 100, 73, 64, 112, 218, 231, 227, 90, 199, 135, 125, 138, 134, 95, 115, 189, 39, 144, 87, 146, 80, 36, 138, 224, 54, 88, 74, 235, 224, 1, 118, 235, 127, 15, 248, 228, 127, 243, 55, 180, 51, 168, 6, 12, 218, 138, 21, 72, 247, 118, 105, 226, 214, 81, 30, 80, 76, 234, 130, 160, 230, 241, 7, 101, 121, 149, 243, 165, 246, 186, 156, 232, 91, 207, 126, 152, 95, 75, 77, 96, 166, 144, 134, 224, 56, 9, 85, 77, 191, 241, 42, 215, 63, 161, 152, 223, 104, 35, 9, 50, 178, 222, 134, 143, 132, 89, 187, 84, 123, 51, 191, 131, 148, 39, 33, 92 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoRecuperacao",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "DataCodigoExpiracao",
                table: "TB_USUARIOS");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoUsuario",
                table: "TB_USUARIOS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 10, 12, 20, 58, 10, 116, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "FotoUsuario", "PasswordHash" },
                values: new object[] { null, new byte[] { 28, 108, 247, 229, 185, 0, 45, 53, 176, 147, 67, 236, 46, 26, 65, 205, 151, 35, 36, 6, 191, 100, 70, 251, 83, 176, 93, 145, 23, 166, 233, 150, 77, 166, 100, 47, 188, 211, 200, 40, 88, 15, 215, 238, 198, 117, 97, 11, 249, 237, 115, 116, 49, 221, 219, 67, 155, 106, 58, 82, 60, 191, 0, 52, 248, 129, 0, 43, 62, 210, 167, 194, 132, 245, 24, 139, 91, 48, 250, 15, 175, 80, 27, 129, 203, 183, 94, 124, 62, 5, 2, 211, 26, 2, 244, 131, 58, 162, 82, 72, 143, 45, 204, 107, 157, 186, 222, 0, 126, 102, 144, 180, 158, 233, 55, 69, 47, 94, 45, 98, 25, 123, 161, 27, 160, 229, 210, 106 } });
        }
    }
}

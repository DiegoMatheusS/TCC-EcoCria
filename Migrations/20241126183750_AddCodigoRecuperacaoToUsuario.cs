using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoRecuperacaoToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 11, 26, 18, 37, 50, 162, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 41, 77, 111, 242, 234, 118, 221, 5, 128, 107, 110, 199, 97, 28, 241, 58, 33, 197, 26, 3, 50, 111, 162, 232, 211, 62, 255, 189, 89, 80, 193, 184, 145, 157, 174, 209, 251, 226, 171, 87, 114, 36, 96, 29, 255, 53, 203, 213, 63, 177, 207, 57, 26, 45, 124, 216, 163, 202, 36, 27, 211, 159, 222, 109, 93, 104, 93, 134, 205, 88, 131, 11, 103, 127, 41, 26, 9, 108, 203, 249, 168, 107, 13, 126, 15, 15, 25, 14, 10, 26, 70, 174, 86, 145, 170, 136, 227, 14, 103, 185, 217, 216, 147, 234, 116, 30, 254, 177, 91, 73, 202, 198, 26, 199, 106, 80, 34, 135, 56, 123, 156, 7, 85, 124, 201, 202, 204, 255 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "PasswordHash",
                value: new byte[] { 154, 249, 225, 145, 95, 247, 8, 173, 255, 243, 181, 237, 100, 73, 64, 112, 218, 231, 227, 90, 199, 135, 125, 138, 134, 95, 115, 189, 39, 144, 87, 146, 80, 36, 138, 224, 54, 88, 74, 235, 224, 1, 118, 235, 127, 15, 248, 228, 127, 243, 55, 180, 51, 168, 6, 12, 218, 138, 21, 72, 247, 118, 105, 226, 214, 81, 30, 80, 76, 234, 130, 160, 230, 241, 7, 101, 121, 149, 243, 165, 246, 186, 156, 232, 91, 207, 126, 152, 95, 75, 77, 96, 166, 144, 134, 224, 56, 9, 85, 77, 191, 241, 42, 215, 63, 161, 152, 223, 104, 35, 9, 50, 178, 222, 134, 143, 132, 89, 187, 84, 123, 51, 191, 131, 148, 39, 33, 92 });
        }
    }
}

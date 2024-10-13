using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class SeedTipoDePontoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "PasswordHash",
                value: new byte[] { 28, 108, 247, 229, 185, 0, 45, 53, 176, 147, 67, 236, 46, 26, 65, 205, 151, 35, 36, 6, 191, 100, 70, 251, 83, 176, 93, 145, 23, 166, 233, 150, 77, 166, 100, 47, 188, 211, 200, 40, 88, 15, 215, 238, 198, 117, 97, 11, 249, 237, 115, 116, 49, 221, 219, 67, 155, 106, 58, 82, 60, 191, 0, 52, 248, 129, 0, 43, 62, 210, 167, 194, 132, 245, 24, 139, 91, 48, 250, 15, 175, 80, 27, 129, 203, 183, 94, 124, 62, 5, 2, 211, 26, 2, 244, 131, 58, 162, 82, 72, 143, 45, 204, 107, 157, 186, 222, 0, 126, 102, 144, 180, 158, 233, 55, 69, 47, 94, 45, 98, 25, 123, 161, 27, 160, 229, 210, 106 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 10, 12, 20, 53, 0, 563, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 30, 167, 158, 23, 149, 132, 108, 120, 245, 151, 96, 179, 12, 78, 44, 35, 225, 216, 190, 203, 148, 73, 133, 23, 74, 107, 128, 12, 211, 111, 213, 73, 136, 197, 121, 200, 193, 100, 94, 83, 86, 201, 82, 5, 146, 209, 39, 86, 23, 97, 69, 114, 120, 101, 117, 255, 42, 219, 65, 200, 184, 243, 211, 90, 191, 132, 27, 18, 54, 57, 26, 188, 157, 70, 187, 59, 206, 255, 178, 157, 186, 183, 59, 124, 15, 68, 224, 237, 94, 186, 118, 53, 9, 201, 228, 145, 63, 128, 243, 107, 78, 40, 71, 80, 71, 235, 94, 251, 43, 185, 157, 188, 23, 81, 53, 47, 133, 151, 118, 216, 112, 224, 88, 183, 49, 139, 192, 15 });
        }
    }
}

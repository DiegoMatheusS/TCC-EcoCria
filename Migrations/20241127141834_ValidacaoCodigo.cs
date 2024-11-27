using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class ValidacaoCodigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 11, 27, 14, 18, 33, 224, DateTimeKind.Local).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 177, 174, 224, 202, 81, 28, 65, 17, 200, 170, 86, 107, 206, 131, 74, 15, 248, 25, 180, 23, 95, 152, 151, 251, 201, 178, 172, 129, 167, 199, 132, 30, 94, 120, 14, 7, 136, 77, 15, 40, 126, 239, 135, 139, 128, 18, 77, 194, 68, 15, 10, 42, 64, 205, 15, 38, 234, 73, 200, 101, 175, 44, 128, 31, 61, 68, 139, 44, 52, 34, 200, 14, 5, 168, 6, 43, 191, 15, 51, 87, 175, 31, 3, 175, 251, 71, 90, 208, 211, 174, 102, 122, 148, 14, 136, 217, 243, 56, 83, 43, 152, 158, 53, 56, 134, 169, 135, 37, 44, 126, 7, 54, 15, 20, 128, 139, 188, 58, 128, 223, 108, 52, 141, 171, 190, 85, 130, 154 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 11, 26, 18, 49, 39, 682, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 68, 81, 5, 132, 133, 183, 58, 133, 168, 47, 61, 130, 224, 102, 135, 215, 104, 165, 210, 135, 25, 187, 33, 40, 208, 195, 217, 104, 126, 91, 176, 182, 52, 223, 43, 169, 38, 189, 99, 140, 188, 121, 171, 114, 122, 24, 66, 182, 192, 107, 223, 46, 157, 134, 102, 214, 64, 117, 18, 133, 187, 121, 141, 122, 221, 235, 197, 123, 113, 253, 10, 213, 162, 60, 227, 241, 171, 120, 113, 29, 54, 209, 241, 85, 208, 91, 58, 177, 146, 232, 145, 243, 95, 63, 151, 177, 160, 135, 123, 198, 232, 61, 255, 236, 55, 175, 114, 121, 209, 81, 55, 66, 19, 17, 199, 82, 26, 35, 66, 110, 251, 44, 25, 125, 64, 85, 129, 172 });
        }
    }
}

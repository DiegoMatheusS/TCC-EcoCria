using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "TB_COMENTARIOS",
                keyColumn: "IdComentario",
                keyValue: 1,
                column: "MomentoComentario",
                value: new DateTime(2024, 11, 27, 18, 27, 4, 715, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 169, 205, 8, 131, 183, 239, 15, 192, 210, 80, 50, 184, 240, 26, 38, 67, 213, 37, 127, 65, 138, 205, 38, 198, 150, 124, 42, 226, 85, 106, 84, 72, 146, 142, 149, 222, 140, 244, 226, 71, 27, 247, 128, 148, 49, 90, 187, 94, 72, 73, 143, 77, 160, 244, 187, 180, 174, 48, 146, 224, 135, 164, 4, 190, 50, 51, 239, 218, 139, 60, 15, 234, 15, 169, 172, 247, 67, 177, 29, 33, 163, 86, 154, 96, 248, 24, 41, 47, 236, 226, 132, 143, 12, 214, 57, 125, 58, 117, 14, 194, 168, 43, 192, 121, 48, 105, 72, 2, 109, 142, 251, 115, 200, 173, 24, 105, 27, 218, 196, 115, 97, 167, 85, 155, 64, 70, 230, 223 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

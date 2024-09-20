using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class PontosMateriais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPontoMaterial",
                table: "TB_PONTOSMATERIAIS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 34, 51, 394, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 34, 238, 215, 34, 199, 62, 72, 156, 217, 143, 47, 189, 220, 148, 153, 172, 27, 98, 229, 146, 162, 19, 156, 163, 172, 226, 169, 123, 164, 63, 160, 205, 136, 38, 34, 125, 52, 68, 37, 167, 161, 191, 1, 249, 58, 217, 178, 232, 68, 245, 229, 204, 118, 122, 251, 47, 225, 184, 77, 121, 125, 200, 9, 56, 237, 114, 48, 127, 57, 22, 10, 145, 150, 230, 222, 77, 93, 213, 81, 130, 86, 229, 165, 108, 190, 108, 166, 186, 63, 166, 151, 147, 148, 243, 182, 94, 223, 114, 19, 54, 170, 15, 149, 3, 119, 251, 238, 233, 211, 43, 59, 80, 51, 246, 249, 72, 192, 113, 207, 29, 1, 164, 90, 137, 67, 183, 122, 87 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPontoMaterial",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 14, 10, 13, 522, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 201, 175, 60, 237, 43, 158, 168, 211, 226, 6, 127, 76, 169, 217, 40, 88, 226, 2, 147, 89, 158, 172, 106, 60, 4, 201, 190, 77, 29, 0, 188, 187, 165, 49, 197, 201, 108, 60, 237, 146, 94, 158, 208, 67, 175, 55, 23, 55, 146, 211, 48, 201, 39, 223, 181, 235, 124, 203, 146, 11, 137, 57, 18, 216, 98, 0, 149, 232, 160, 223, 144, 176, 237, 93, 242, 159, 211, 226, 153, 80, 134, 179, 237, 152, 148, 154, 133, 99, 176, 103, 92, 94, 18, 115, 66, 0, 199, 114, 93, 4, 159, 58, 32, 22, 185, 86, 210, 252, 192, 87, 230, 242, 52, 180, 223, 162, 119, 209, 167, 218, 117, 244, 45, 62, 230, 108, 91, 87 });
        }
    }
}

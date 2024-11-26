using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoRecuperacaoToUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoRecuperacao",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "DataCodigoExpiracao",
                table: "TB_USUARIOS");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CodigoRecuperacao", "DataCodigoExpiracao", "PasswordHash" },
                values: new object[] { "", null, new byte[] { 41, 77, 111, 242, 234, 118, 221, 5, 128, 107, 110, 199, 97, 28, 241, 58, 33, 197, 26, 3, 50, 111, 162, 232, 211, 62, 255, 189, 89, 80, 193, 184, 145, 157, 174, 209, 251, 226, 171, 87, 114, 36, 96, 29, 255, 53, 203, 213, 63, 177, 207, 57, 26, 45, 124, 216, 163, 202, 36, 27, 211, 159, 222, 109, 93, 104, 93, 134, 205, 88, 131, 11, 103, 127, 41, 26, 9, 108, 203, 249, 168, 107, 13, 126, 15, 15, 25, 14, 10, 26, 70, 174, 86, 145, 170, 136, 227, 14, 103, 185, 217, 216, 147, 234, 116, 30, 254, 177, 91, 73, 202, 198, 26, 199, 106, 80, 34, 135, 56, 123, 156, 7, 85, 124, 201, 202, 204, 255 } });
        }
    }
}

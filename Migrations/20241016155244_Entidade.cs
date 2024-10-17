using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class Entidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "TB_CONTATO",
                type: "Varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 16, 12, 52, 43, 720, DateTimeKind.Local).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 146, 74, 245, 131, 15, 237, 1, 92, 40, 90, 14, 32, 167, 77, 65, 82, 233, 129, 32, 44, 217, 129, 54, 207, 4, 250, 159, 224, 48, 37, 161, 160, 67, 22, 209, 171, 64, 82, 177, 164, 82, 5, 32, 208, 191, 244, 171, 214, 201, 12, 127, 197, 93, 135, 202, 85, 254, 131, 174, 154, 32, 70, 188, 209, 0, 190, 135, 131, 242, 222, 93, 44, 165, 75, 160, 252, 40, 37, 151, 103, 64, 41, 226, 8, 245, 150, 226, 121, 135, 207, 158, 210, 215, 41, 125, 176, 159, 66, 227, 177, 214, 228, 168, 64, 197, 85, 49, 101, 109, 172, 32, 72, 46, 228, 27, 229, 14, 238, 244, 232, 234, 104, 169, 184, 226, 91, 213, 162 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "TB_CONTATO");

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 17, 16, 57, 929, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 237, 239, 164, 4, 2, 220, 94, 16, 113, 71, 114, 40, 64, 164, 54, 61, 83, 78, 25, 45, 37, 45, 139, 132, 248, 219, 57, 44, 182, 158, 77, 255, 59, 138, 175, 16, 39, 5, 62, 161, 141, 11, 99, 209, 115, 32, 214, 186, 202, 70, 80, 173, 150, 212, 59, 69, 148, 68, 72, 181, 126, 92, 192, 84, 50, 201, 190, 112, 193, 39, 171, 228, 145, 124, 228, 98, 245, 181, 150, 213, 65, 139, 223, 18, 206, 91, 165, 116, 8, 85, 128, 12, 13, 169, 249, 120, 65, 216, 208, 42, 230, 141, 132, 130, 101, 103, 62, 116, 219, 220, 105, 113, 45, 85, 235, 220, 97, 30, 17, 97, 201, 56, 216, 46, 63, 48, 45, 60 });
        }
    }
}

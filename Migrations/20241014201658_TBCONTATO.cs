using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class TBCONTATO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 10, 14, 16, 47, 49, 904, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 20, 17, 236, 208, 151, 96, 232, 189, 15, 139, 115, 78, 150, 23, 244, 222, 163, 239, 24, 252, 253, 202, 253, 6, 199, 150, 78, 198, 232, 13, 150, 167, 126, 66, 49, 217, 139, 200, 0, 246, 87, 3, 61, 22, 45, 10, 209, 33, 252, 185, 249, 147, 178, 15, 175, 116, 231, 13, 87, 7, 189, 75, 193, 209, 60, 10, 10, 242, 4, 64, 131, 174, 27, 142, 221, 80, 238, 209, 173, 224, 193, 38, 222, 72, 37, 189, 217, 75, 157, 229, 149, 124, 12, 213, 16, 71, 34, 16, 229, 84, 223, 96, 23, 128, 129, 207, 157, 203, 228, 84, 96, 141, 81, 228, 95, 38, 36, 62, 108, 119, 212, 53, 114, 170, 53, 157, 79, 61 });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class UmParaUmPontosTipoPontos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPonto",
                table: "TB_TIPOPONTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdPonto",
                table: "TB_PONTOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 93, 178, 207, 244, 151, 242, 194, 132, 187, 137, 114, 201, 129, 32, 27, 12, 20, 115, 93, 45, 188, 131, 71, 230, 123, 98, 79, 51, 218, 154, 147, 155, 145, 236, 23, 150, 91, 73, 161, 136, 207, 241, 59, 41, 116, 155, 145, 101, 151, 93, 97, 225, 31, 145, 43, 120, 128, 161, 246, 184, 9, 188, 112, 24, 64, 40, 97, 84, 239, 236, 104, 142, 6, 199, 144, 204, 249, 78, 246, 237, 93, 209, 227, 8, 132, 52, 152, 104, 52, 137, 32, 249, 109, 48, 124, 223, 48, 39, 61, 211, 186, 169, 190, 230, 25, 228, 246, 253, 227, 246, 91, 26, 155, 55, 141, 9, 255, 189, 135, 67, 231, 83, 229, 13, 253, 203, 167, 219 });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PONTOS_TB_TIPOPONTO_IdPonto",
                table: "TB_PONTOS",
                column: "IdPonto",
                principalTable: "TB_TIPOPONTO",
                principalColumn: "IdTipoPonto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PONTOS_TB_TIPOPONTO_IdPonto",
                table: "TB_PONTOS");

            migrationBuilder.DropColumn(
                name: "IdPonto",
                table: "TB_TIPOPONTO");

            migrationBuilder.AlterColumn<int>(
                name: "IdPonto",
                table: "TB_PONTOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 58, 21, 63, 103, 119, 209, 30, 120, 56, 64, 9, 101, 232, 111, 116, 120, 60, 102, 242, 31, 9, 145, 4, 43, 107, 243, 116, 236, 227, 210, 48, 53, 252, 61, 81, 76, 167, 206, 214, 120, 236, 32, 204, 150, 41, 101, 221, 51, 214, 31, 50, 254, 134, 136, 241, 76, 31, 40, 138, 51, 177, 90, 22, 187, 218, 32, 59, 28, 77, 14, 81, 50, 74, 153, 138, 33, 228, 238, 156, 124, 211, 192, 15, 18, 70, 219, 8, 157, 227, 75, 6, 1, 57, 86, 161, 23, 236, 152, 139, 173, 125, 65, 202, 233, 37, 120, 252, 37, 151, 230, 229, 87, 18, 116, 39, 204, 101, 105, 52, 29, 167, 142, 117, 63, 61, 58, 102, 138 });
        }
    }
}

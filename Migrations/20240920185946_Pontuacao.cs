using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOCRIA.Migrations
{
    /// <inheritdoc />
    public partial class Pontuacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPontuacao",
                table: "TB_PONTUACAO",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ColetasIdColeta",
                table: "TB_PONTUACAO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdColeta",
                table: "TB_PONTUACAO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "TB_PONTUACAO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "TB_PONTUACAO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMaterial",
                table: "TB_PONTOSMATERIAIS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPonto",
                table: "TB_PONTOSMATERIAIS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriaisIdMaterial",
                table: "TB_PONTOSMATERIAIS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PontosIdPonto",
                table: "TB_PONTOSMATERIAIS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdOrdemGrandeza",
                table: "TB_MATERIAIS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdemDeGrandezaIdOrdemGrandeza",
                table: "TB_MATERIAIS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_PONTUACAO",
                table: "TB_PONTUACAO",
                column: "IdPontuacao");

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 1,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 2,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 3,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 4,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 5,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 6,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "TB_COLETAS",
                keyColumn: "IdColeta",
                keyValue: 7,
                column: "MomentoColeta",
                value: new DateTime(2024, 9, 20, 15, 59, 45, 514, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 1,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 2,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 3,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 4,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 5,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 6,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_MATERIAIS",
                keyColumn: "IdMaterial",
                keyValue: 7,
                columns: new[] { "IdOrdemGrandeza", "OrdemDeGrandezaIdOrdemGrandeza" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "PasswordHash",
                value: new byte[] { 93, 194, 100, 207, 115, 148, 117, 130, 78, 97, 182, 85, 216, 157, 90, 201, 71, 28, 106, 11, 76, 9, 231, 229, 223, 9, 96, 180, 169, 27, 139, 212, 7, 130, 55, 95, 162, 121, 59, 144, 0, 9, 230, 89, 242, 51, 210, 193, 176, 41, 173, 126, 70, 113, 80, 192, 75, 11, 132, 215, 79, 130, 97, 43, 4, 86, 62, 184, 17, 151, 72, 84, 62, 50, 180, 186, 217, 13, 11, 28, 45, 66, 26, 204, 208, 247, 87, 33, 102, 249, 39, 62, 237, 187, 254, 59, 224, 150, 64, 178, 55, 27, 29, 150, 155, 117, 106, 252, 23, 53, 172, 240, 60, 180, 32, 160, 2, 178, 201, 166, 95, 113, 45, 115, 161, 233, 214, 200 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTUACAO_ColetasIdColeta",
                table: "TB_PONTUACAO",
                column: "ColetasIdColeta");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTUACAO_UsuarioIdUsuario",
                table: "TB_PONTUACAO",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTOSMATERIAIS_MateriaisIdMaterial",
                table: "TB_PONTOSMATERIAIS",
                column: "MateriaisIdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTOSMATERIAIS_PontosIdPonto",
                table: "TB_PONTOSMATERIAIS",
                column: "PontosIdPonto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATERIAIS_OrdemDeGrandezaIdOrdemGrandeza",
                table: "TB_MATERIAIS",
                column: "OrdemDeGrandezaIdOrdemGrandeza");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MATERIAIS_TB_ORDEMGRANDEZA_OrdemDeGrandezaIdOrdemGrandeza",
                table: "TB_MATERIAIS",
                column: "OrdemDeGrandezaIdOrdemGrandeza",
                principalTable: "TB_ORDEMGRANDEZA",
                principalColumn: "IdOrdemGrandeza");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PONTOSMATERIAIS_TB_MATERIAIS_MateriaisIdMaterial",
                table: "TB_PONTOSMATERIAIS",
                column: "MateriaisIdMaterial",
                principalTable: "TB_MATERIAIS",
                principalColumn: "IdMaterial");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PONTOSMATERIAIS_TB_PONTOS_PontosIdPonto",
                table: "TB_PONTOSMATERIAIS",
                column: "PontosIdPonto",
                principalTable: "TB_PONTOS",
                principalColumn: "IdPonto");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PONTUACAO_TB_COLETAS_ColetasIdColeta",
                table: "TB_PONTUACAO",
                column: "ColetasIdColeta",
                principalTable: "TB_COLETAS",
                principalColumn: "IdColeta");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PONTUACAO_TB_USUARIOS_UsuarioIdUsuario",
                table: "TB_PONTUACAO",
                column: "UsuarioIdUsuario",
                principalTable: "TB_USUARIOS",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MATERIAIS_TB_ORDEMGRANDEZA_OrdemDeGrandezaIdOrdemGrandeza",
                table: "TB_MATERIAIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PONTOSMATERIAIS_TB_MATERIAIS_MateriaisIdMaterial",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PONTOSMATERIAIS_TB_PONTOS_PontosIdPonto",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PONTUACAO_TB_COLETAS_ColetasIdColeta",
                table: "TB_PONTUACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PONTUACAO_TB_USUARIOS_UsuarioIdUsuario",
                table: "TB_PONTUACAO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_PONTUACAO",
                table: "TB_PONTUACAO");

            migrationBuilder.DropIndex(
                name: "IX_TB_PONTUACAO_ColetasIdColeta",
                table: "TB_PONTUACAO");

            migrationBuilder.DropIndex(
                name: "IX_TB_PONTUACAO_UsuarioIdUsuario",
                table: "TB_PONTUACAO");

            migrationBuilder.DropIndex(
                name: "IX_TB_PONTOSMATERIAIS_MateriaisIdMaterial",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PONTOSMATERIAIS_PontosIdPonto",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropIndex(
                name: "IX_TB_MATERIAIS_OrdemDeGrandezaIdOrdemGrandeza",
                table: "TB_MATERIAIS");

            migrationBuilder.DropColumn(
                name: "IdPontuacao",
                table: "TB_PONTUACAO");

            migrationBuilder.DropColumn(
                name: "ColetasIdColeta",
                table: "TB_PONTUACAO");

            migrationBuilder.DropColumn(
                name: "IdColeta",
                table: "TB_PONTUACAO");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "TB_PONTUACAO");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "TB_PONTUACAO");

            migrationBuilder.DropColumn(
                name: "IdMaterial",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropColumn(
                name: "IdPonto",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropColumn(
                name: "MateriaisIdMaterial",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropColumn(
                name: "PontosIdPonto",
                table: "TB_PONTOSMATERIAIS");

            migrationBuilder.DropColumn(
                name: "IdOrdemGrandeza",
                table: "TB_MATERIAIS");

            migrationBuilder.DropColumn(
                name: "OrdemDeGrandezaIdOrdemGrandeza",
                table: "TB_MATERIAIS");

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
    }
}

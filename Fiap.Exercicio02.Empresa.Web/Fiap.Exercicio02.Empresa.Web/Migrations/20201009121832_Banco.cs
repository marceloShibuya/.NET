using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Exercicio02.Empresa.Web.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstituicaoId",
                table: "Tbl_Funcionario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Funcionario_InstituicaoId",
                table: "Tbl_Funcionario",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Funcionario_Tbl_Instituicao_InstituicaoId",
                table: "Tbl_Funcionario",
                column: "InstituicaoId",
                principalTable: "Tbl_Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Funcionario_Tbl_Instituicao_InstituicaoId",
                table: "Tbl_Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Funcionario_InstituicaoId",
                table: "Tbl_Funcionario");

            migrationBuilder.DropColumn(
                name: "InstituicaoId",
                table: "Tbl_Funcionario");
        }
    }
}

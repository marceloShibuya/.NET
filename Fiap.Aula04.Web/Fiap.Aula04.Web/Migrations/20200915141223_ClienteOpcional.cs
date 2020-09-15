using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula04.Web.Migrations
{
    public partial class ClienteOpcional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Cliente_ClienteId",
                table: "Tbl_Veiculo");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Tbl_Veiculo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Cliente_ClienteId",
                table: "Tbl_Veiculo",
                column: "ClienteId",
                principalTable: "Tbl_Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Cliente_ClienteId",
                table: "Tbl_Veiculo");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Tbl_Veiculo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Cliente_ClienteId",
                table: "Tbl_Veiculo",
                column: "ClienteId",
                principalTable: "Tbl_Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

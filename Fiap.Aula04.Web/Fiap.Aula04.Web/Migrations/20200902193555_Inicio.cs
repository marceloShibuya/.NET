using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula04.Web.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(maxLength: 50, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Dt_Fabricacao = table.Column<DateTime>(nullable: false),
                    Novo = table.Column<bool>(nullable: false),
                    Combustivel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Veiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Veiculo");
        }
    }
}

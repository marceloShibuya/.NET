using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula04.Web.Migrations
{
    public partial class TabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Pcd = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Cliente");
        }
    }
}

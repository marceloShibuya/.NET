using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula04.Web.Migrations
{
    public partial class TabelaTestDrive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Test_Drive",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Test_Drive", x => new { x.ClienteId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_Tbl_Test_Drive_Tbl_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Tbl_Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Test_Drive_Tbl_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Tbl_Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Test_Drive_VeiculoId",
                table: "Tbl_Test_Drive",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Test_Drive");
        }
    }
}

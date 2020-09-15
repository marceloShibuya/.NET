using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula04.Web.Migrations
{
    public partial class Relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Tbl_Veiculo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlacaId",
                table: "Tbl_Veiculo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(maxLength: 80, nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Placa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(maxLength: 8, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Placa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCliente",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    EnderecoId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCliente", x => new { x.ClienteId, x.EnderecoId });
                    table.ForeignKey(
                        name: "FK_EnderecoCliente_Tbl_Cliente_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoCliente_Tbl_Endereco_EnderecoId1",
                        column: x => x.EnderecoId1,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Veiculo_ClienteId",
                table: "Tbl_Veiculo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Veiculo_PlacaId",
                table: "Tbl_Veiculo",
                column: "PlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCliente_EnderecoId",
                table: "EnderecoCliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCliente_EnderecoId1",
                table: "EnderecoCliente",
                column: "EnderecoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Cliente_ClienteId",
                table: "Tbl_Veiculo",
                column: "ClienteId",
                principalTable: "Tbl_Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Placa_PlacaId",
                table: "Tbl_Veiculo",
                column: "PlacaId",
                principalTable: "Tbl_Placa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Cliente_ClienteId",
                table: "Tbl_Veiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Veiculo_Tbl_Placa_PlacaId",
                table: "Tbl_Veiculo");

            migrationBuilder.DropTable(
                name: "EnderecoCliente");

            migrationBuilder.DropTable(
                name: "Tbl_Placa");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Veiculo_ClienteId",
                table: "Tbl_Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Veiculo_PlacaId",
                table: "Tbl_Veiculo");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Tbl_Veiculo");

            migrationBuilder.DropColumn(
                name: "PlacaId",
                table: "Tbl_Veiculo");
        }
    }
}

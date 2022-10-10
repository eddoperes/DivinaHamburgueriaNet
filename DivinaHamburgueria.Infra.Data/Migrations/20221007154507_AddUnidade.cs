using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class AddUnidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnidadeId",
                table: "ItensDoCardapio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoCardapio_UnidadeId",
                table: "ItensDoCardapio",
                column: "UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_Unidades_UnidadeId",
                table: "ItensDoCardapio",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_Unidades_UnidadeId",
                table: "ItensDoCardapio");

            migrationBuilder.DropIndex(
                name: "IX_ItensDoCardapio_UnidadeId",
                table: "ItensDoCardapio");

            migrationBuilder.DropColumn(
                name: "UnidadeId",
                table: "ItensDoCardapio");
        }
    }
}

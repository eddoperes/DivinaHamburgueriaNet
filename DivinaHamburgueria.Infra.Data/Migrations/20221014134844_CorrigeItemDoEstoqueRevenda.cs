using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class CorrigeItemDoEstoqueRevenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ItensDoEstoque");

            migrationBuilder.AddColumn<int>(
                name: "ItemDoEstoqueRevenda_ComestivelId",
                table: "ItensDoEstoque",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoEstoque_ItemDoEstoqueRevenda_ComestivelId",
                table: "ItensDoEstoque",
                column: "ItemDoEstoqueRevenda_ComestivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ItemDoEstoqueRevenda_ComestivelId",
                table: "ItensDoEstoque",
                column: "ItemDoEstoqueRevenda_ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ItemDoEstoqueRevenda_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_ItensDoEstoque_ItemDoEstoqueRevenda_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropColumn(
                name: "ItemDoEstoqueRevenda_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ItensDoEstoque",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class CorrigeItemDoEstoqueNomeTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_ItemDoEstoque_ItemDoEstoqueId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDoEstoque_Comestiveis_ComestivelId",
                table: "ItemDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemDoEstoque_Unidades_UnidadeId",
                table: "ItemDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_ItemDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItemDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDoEstoque",
                table: "ItemDoEstoque");

            migrationBuilder.RenameTable(
                name: "ItemDoEstoque",
                newName: "ItensDoEstoque");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDoEstoque_UnidadeId",
                table: "ItensDoEstoque",
                newName: "IX_ItensDoEstoque_UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDoEstoque_ComestivelId",
                table: "ItensDoEstoque",
                newName: "IX_ItensDoEstoque_ComestivelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensDoEstoque",
                table: "ItensDoEstoque",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_ItensDoEstoque_ItemDoEstoqueId",
                table: "Estoques",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_ItensDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ComestivelId",
                table: "ItensDoEstoque",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoEstoque_Unidades_UnidadeId",
                table: "ItensDoEstoque",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_ItensDoEstoque_ItemDoEstoqueId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_ItensDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoEstoque_Unidades_UnidadeId",
                table: "ItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensDoEstoque",
                table: "ItensDoEstoque");

            migrationBuilder.RenameTable(
                name: "ItensDoEstoque",
                newName: "ItemDoEstoque");

            migrationBuilder.RenameIndex(
                name: "IX_ItensDoEstoque_UnidadeId",
                table: "ItemDoEstoque",
                newName: "IX_ItemDoEstoque_UnidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensDoEstoque_ComestivelId",
                table: "ItemDoEstoque",
                newName: "IX_ItemDoEstoque_ComestivelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDoEstoque",
                table: "ItemDoEstoque",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_ItemDoEstoque_ItemDoEstoqueId",
                table: "Estoques",
                column: "ItemDoEstoqueId",
                principalTable: "ItemDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDoEstoque_Comestiveis_ComestivelId",
                table: "ItemDoEstoque",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDoEstoque_Unidades_UnidadeId",
                table: "ItemDoEstoque",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_ItemDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio",
                column: "ItemDoEstoqueId",
                principalTable: "ItemDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItemDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "ItemDoEstoqueId",
                principalTable: "ItemDoEstoque",
                principalColumn: "Id");
        }
    }
}

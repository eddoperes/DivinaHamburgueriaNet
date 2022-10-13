using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class AddIngrediente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_Comestiveis_ComestivelId",
                table: "ItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_Unidades_UnidadeId",
                table: "ItensDoCardapio");

            migrationBuilder.DropIndex(
                name: "IX_ItensDoCardapio_ComestivelId",
                table: "ItensDoCardapio");

            migrationBuilder.DropIndex(
                name: "IX_ItensDoCardapio_UnidadeId",
                table: "ItensDoCardapio");

            migrationBuilder.DropColumn(
                name: "ComestivelId",
                table: "ItensDoCardapio");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItensDoCardapio");

            migrationBuilder.DropColumn(
                name: "UnidadeId",
                table: "ItensDoCardapio");

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComestivelId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false),
                    ItemDoCardapioReceitaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Comestiveis_ComestivelId",
                        column: x => x.ComestivelId,
                        principalTable: "Comestiveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_ItensDoCardapio_ItemDoCardapioReceitaId",
                        column: x => x.ItemDoCardapioReceitaId,
                        principalTable: "ItensDoCardapio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredientes_Unidades_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ComestivelId",
                table: "Ingredientes",
                column: "ComestivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ItemDoCardapioReceitaId",
                table: "Ingredientes",
                column: "ItemDoCardapioReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_UnidadeId",
                table: "Ingredientes",
                column: "UnidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.AddColumn<int>(
                name: "ComestivelId",
                table: "ItensDoCardapio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItensDoCardapio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeId",
                table: "ItensDoCardapio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoCardapio_ComestivelId",
                table: "ItensDoCardapio",
                column: "ComestivelId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoCardapio_UnidadeId",
                table: "ItensDoCardapio",
                column: "UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_Comestiveis_ComestivelId",
                table: "ItensDoCardapio",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_Unidades_UnidadeId",
                table: "ItensDoCardapio",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

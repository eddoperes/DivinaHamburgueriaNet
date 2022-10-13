using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class AlterItemDoEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ItensDoEstoque");

            migrationBuilder.AddColumn<int>(
                name: "ComestivelId",
                table: "ItensDoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoEstoque_ComestivelId",
                table: "ItensDoEstoque",
                column: "ComestivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ComestivelId",
                table: "ItensDoEstoque",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_ItensDoEstoque_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropColumn(
                name: "ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ItensDoEstoque",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

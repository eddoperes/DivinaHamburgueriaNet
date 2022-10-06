﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class CardapioItemDoCardapio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Cardapios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ItemDoCardapio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDoCardapio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardapiosItensDoCardapio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardapioId = table.Column<int>(type: "int", nullable: false),
                    ItemDoCardapioId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtivado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInativado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardapiosItensDoCardapio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardapiosItensDoCardapio_Cardapios_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardapiosItensDoCardapio_ItemDoCardapio_ItemDoCardapioId",
                        column: x => x.ItemDoCardapioId,
                        principalTable: "ItemDoCardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardapiosItensDoCardapio_CardapioId",
                table: "CardapiosItensDoCardapio",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_CardapiosItensDoCardapio_ItemDoCardapioId",
                table: "CardapiosItensDoCardapio",
                column: "ItemDoCardapioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardapiosItensDoCardapio");

            migrationBuilder.DropTable(
                name: "ItemDoCardapio");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Cardapios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}

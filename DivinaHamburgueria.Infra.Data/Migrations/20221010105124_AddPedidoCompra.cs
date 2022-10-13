using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class AddPedidoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDeCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEmitido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCancelado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntregue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEstocado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoPagamento = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosDeCompra_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDeCompraItensDoEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoDeCompraId = table.Column<int>(type: "int", nullable: false),
                    ItemDoEstoqueId = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Estocado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeCompraItensDoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                        column: x => x.ItemDoEstoqueId,
                        principalTable: "ItensDoEstoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosDeCompraItensDoEstoque_PedidosDeCompra_PedidoDeCompraId",
                        column: x => x.PedidoDeCompraId,
                        principalTable: "PedidosDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeCompra_FornecedorId",
                table: "PedidosDeCompra",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeCompraItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "ItemDoEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeCompraItensDoEstoque_PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "PedidoDeCompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropTable(
                name: "PedidosDeCompra");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}

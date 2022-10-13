using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class InheritanceItemDoEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Comestiveis_ComestivelId",
                table: "Alarmes");

            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Unidades_UnidadeId",
                table: "Alarmes");

            migrationBuilder.DropForeignKey(
                name: "FK_CardapiosItensDoCardapio_Cardapios_CardapioId",
                table: "CardapiosItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_CardapiosItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "CardapiosItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_ItensDoEstoque_ItemDoEstoqueId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Comestiveis_ComestivelId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Unidades_UnidadeId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_ItensDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompra_Fornecedores_FornecedorId",
                table: "PedidosDeCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_PedidosDeCompra_PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosDeliveryItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_Pedidos_PedidoDeliveryId",
                table: "PedidosDeliveryItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosSalaoItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_Pedidos_PedidoSalaoId",
                table: "PedidosSalaoItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Fornecedores_FornecedorId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_ItensDoEstoque_ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropColumn(
                name: "ComestivelId",
                table: "ItensDoEstoque");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "ItensDoEstoque");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoSalaoId",
                table: "PedidosSalaoItensDoCardapio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoCardapioId",
                table: "PedidosSalaoItensDoCardapio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoDeliveryId",
                table: "PedidosDeliveryItensDoCardapio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoCardapioId",
                table: "PedidosDeliveryItensDoCardapio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "PedidosDeCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UnidadeId",
                table: "Ingredientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ComestivelId",
                table: "Ingredientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoEstoqueId",
                table: "Estoques",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoCardapioId",
                table: "CardapiosItensDoCardapio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CardapioId",
                table: "CardapiosItensDoCardapio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UnidadeId",
                table: "Alarmes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ComestivelId",
                table: "Alarmes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Comestiveis_ComestivelId",
                table: "Alarmes",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Unidades_UnidadeId",
                table: "Alarmes",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardapiosItensDoCardapio_Cardapios_CardapioId",
                table: "CardapiosItensDoCardapio",
                column: "CardapioId",
                principalTable: "Cardapios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardapiosItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "CardapiosItensDoCardapio",
                column: "ItemDoCardapioId",
                principalTable: "ItensDoCardapio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_ItensDoEstoque_ItemDoEstoqueId",
                table: "Estoques",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Comestiveis_ComestivelId",
                table: "Ingredientes",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Unidades_UnidadeId",
                table: "Ingredientes",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_ItensDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompra_Fornecedores_FornecedorId",
                table: "PedidosDeCompra",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_PedidosDeCompra_PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "PedidoDeCompraId",
                principalTable: "PedidosDeCompra",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosDeliveryItensDoCardapio",
                column: "ItemDoCardapioId",
                principalTable: "ItensDoCardapio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_Pedidos_PedidoDeliveryId",
                table: "PedidosDeliveryItensDoCardapio",
                column: "PedidoDeliveryId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosSalaoItensDoCardapio",
                column: "ItemDoCardapioId",
                principalTable: "ItensDoCardapio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_Pedidos_PedidoSalaoId",
                table: "PedidosSalaoItensDoCardapio",
                column: "PedidoSalaoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Fornecedores_FornecedorId",
                table: "Telefones",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Comestiveis_ComestivelId",
                table: "Alarmes");

            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Unidades_UnidadeId",
                table: "Alarmes");

            migrationBuilder.DropForeignKey(
                name: "FK_CardapiosItensDoCardapio_Cardapios_CardapioId",
                table: "CardapiosItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_CardapiosItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "CardapiosItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_ItensDoEstoque_ItemDoEstoqueId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Comestiveis_ComestivelId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Unidades_UnidadeId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensDoCardapio_ItensDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompra_Fornecedores_FornecedorId",
                table: "PedidosDeCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_PedidosDeCompra_PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosDeliveryItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_Pedidos_PedidoDeliveryId",
                table: "PedidosDeliveryItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosSalaoItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_Pedidos_PedidoSalaoId",
                table: "PedidosSalaoItensDoCardapio");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Fornecedores_FornecedorId",
                table: "Telefones");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoSalaoId",
                table: "PedidosSalaoItensDoCardapio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoCardapioId",
                table: "PedidosSalaoItensDoCardapio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoDeliveryId",
                table: "PedidosDeliveryItensDoCardapio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoCardapioId",
                table: "PedidosDeliveryItensDoCardapio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "PedidosDeCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComestivelId",
                table: "ItensDoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "ItensDoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UnidadeId",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComestivelId",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoEstoqueId",
                table: "Estoques",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDoCardapioId",
                table: "CardapiosItensDoCardapio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CardapioId",
                table: "CardapiosItensDoCardapio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnidadeId",
                table: "Alarmes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComestivelId",
                table: "Alarmes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoEstoque_ComestivelId",
                table: "ItensDoEstoque",
                column: "ComestivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Comestiveis_ComestivelId",
                table: "Alarmes",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Unidades_UnidadeId",
                table: "Alarmes",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardapiosItensDoCardapio_Cardapios_CardapioId",
                table: "CardapiosItensDoCardapio",
                column: "CardapioId",
                principalTable: "Cardapios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardapiosItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "CardapiosItensDoCardapio",
                column: "ItemDoCardapioId",
                principalTable: "ItensDoCardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Fornecedores_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_ItensDoEstoque_ItemDoEstoqueId",
                table: "Estoques",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Comestiveis_ComestivelId",
                table: "Ingredientes",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Unidades_UnidadeId",
                table: "Ingredientes",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoCardapio_ItensDoEstoque_ItemDoEstoqueId",
                table: "ItensDoCardapio",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensDoEstoque_Comestiveis_ComestivelId",
                table: "ItensDoEstoque",
                column: "ComestivelId",
                principalTable: "Comestiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompra_Fornecedores_FornecedorId",
                table: "PedidosDeCompra",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_ItensDoEstoque_ItemDoEstoqueId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "ItemDoEstoqueId",
                principalTable: "ItensDoEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeCompraItensDoEstoque_PedidosDeCompra_PedidoDeCompraId",
                table: "PedidosDeCompraItensDoEstoque",
                column: "PedidoDeCompraId",
                principalTable: "PedidosDeCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosDeliveryItensDoCardapio",
                column: "ItemDoCardapioId",
                principalTable: "ItensDoCardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeliveryItensDoCardapio_Pedidos_PedidoDeliveryId",
                table: "PedidosDeliveryItensDoCardapio",
                column: "PedidoDeliveryId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_ItensDoCardapio_ItemDoCardapioId",
                table: "PedidosSalaoItensDoCardapio",
                column: "ItemDoCardapioId",
                principalTable: "ItensDoCardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosSalaoItensDoCardapio_Pedidos_PedidoSalaoId",
                table: "PedidosSalaoItensDoCardapio",
                column: "PedidoSalaoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Fornecedores_FornecedorId",
                table: "Telefones",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

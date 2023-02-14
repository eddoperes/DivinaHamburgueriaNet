using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class AddSupervisedFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stocked",
                table: "PurchaseOrdersInventoryItems");

            migrationBuilder.AddColumn<bool>(
                name: "Supervised",
                table: "PurchaseOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeliveryOrder_Supervised",
                table: "Orders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Supervised",
                table: "Orders",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuantityAlarmsTriggered",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EatableId = table.Column<int>(type: "int", nullable: false),
                    MinimumQuantity = table.Column<int>(type: "int", nullable: false),
                    VerifiedQuantity = table.Column<int>(type: "int", nullable: false),
                    UnityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityAlarmsTriggered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantityAlarmsTriggered_Eatables_EatableId",
                        column: x => x.EatableId,
                        principalTable: "Eatables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantityAlarmsTriggered_Units_UnityId",
                        column: x => x.UnityId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidityAlarmsTriggered",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EatableId = table.Column<int>(type: "int", nullable: false),
                    ValidityInDays = table.Column<int>(type: "int", nullable: false),
                    VerifiedInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidityAlarmsTriggered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidityAlarmsTriggered_Eatables_EatableId",
                        column: x => x.EatableId,
                        principalTable: "Eatables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuantityAlarmsTriggered_EatableId",
                table: "QuantityAlarmsTriggered",
                column: "EatableId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityAlarmsTriggered_UnityId",
                table: "QuantityAlarmsTriggered",
                column: "UnityId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidityAlarmsTriggered_EatableId",
                table: "ValidityAlarmsTriggered",
                column: "EatableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityAlarmsTriggered");

            migrationBuilder.DropTable(
                name: "ValidityAlarmsTriggered");

            migrationBuilder.DropColumn(
                name: "Supervised",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryOrder_Supervised",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Supervised",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "Stocked",
                table: "PurchaseOrdersInventoryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

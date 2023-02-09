using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class CorrectAlarmAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerifiedInDays",
                table: "ValidityAlarmsTriggered",
                newName: "PossiblySpoiled");

            migrationBuilder.AddColumn<int>(
                name: "UnityId",
                table: "ValidityAlarmsTriggered",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ValidityAlarmsTriggered_UnityId",
                table: "ValidityAlarmsTriggered",
                column: "UnityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ValidityAlarmsTriggered_Units_UnityId",
                table: "ValidityAlarmsTriggered",
                column: "UnityId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidityAlarmsTriggered_Units_UnityId",
                table: "ValidityAlarmsTriggered");

            migrationBuilder.DropIndex(
                name: "IX_ValidityAlarmsTriggered_UnityId",
                table: "ValidityAlarmsTriggered");

            migrationBuilder.DropColumn(
                name: "UnityId",
                table: "ValidityAlarmsTriggered");

            migrationBuilder.RenameColumn(
                name: "PossiblySpoiled",
                table: "ValidityAlarmsTriggered",
                newName: "VerifiedInDays");
        }
    }
}

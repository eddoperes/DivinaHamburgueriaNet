using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class CorrectValueObjects_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_CreationDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Phone_CreationDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_CreationDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone_CreationDate",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Address_CreationDate",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Phone_CreationDate",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Address_CreationDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Phone_CreationDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }
    }
}

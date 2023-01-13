using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivinaHamburgueria.Infra.Data.Migrations
{
    public partial class CorrectValueObjects_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Providers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Complement",
                table: "Providers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Address_CreationDate",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Providers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_FederationUnity",
                table: "Providers",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_Number",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Providers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Providers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Phone_CreationDate",
                table: "Providers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_DDD",
                table: "Providers",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Providers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Complement",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Address_CreationDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_FederationUnity",
                table: "Customers",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_Number",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Customers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Phone_CreationDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_DDD",
                table: "Customers",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_Number",
                table: "Customers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_Complement",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_CreationDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_FederationUnity",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Phone_CreationDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Phone_DDD",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Complement",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_CreationDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_FederationUnity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone_CreationDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone_DDD",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone_Number",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FederationUnity = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}

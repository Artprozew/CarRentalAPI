using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<long>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CarModel = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: false),
                    Manufacturer = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: false),
                    CarType = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Plate = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    CarYear = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Color = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Mileage = table.Column<long>(type: "NUMBER(7)", precision: 7, nullable: false),
                    RentPrice = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(75)", maxLength: 75, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<long>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CustomerId = table.Column<long>(type: "NUMBER(10)", nullable: false),
                    CarId = table.Column<long>(type: "NUMBER(10)", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HasReturned = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rental_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK_Rental_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarId",
                table: "Rental",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CustomerId",
                table: "Rental",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}

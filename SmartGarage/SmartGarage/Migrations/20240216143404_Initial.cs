using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGarage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isOnline = table.Column<bool>(type: "bit", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    CarModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.CarModelID);
                    table.ForeignKey(
                        name: "FK_CarModels_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true),
                    CarModelID = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_CarModels_CarModelID",
                        column: x => x.CarModelID,
                        principalTable: "CarModels",
                        principalColumn: "CarModelID");
                    table.ForeignKey(
                        name: "FK_Vehicles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerID");
                });

            migrationBuilder.CreateTable(
                name: "LinkedVehicles",
                columns: table => new
                {
                    LinkedVehiclelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    YearOfCreation = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedVehicles", x => x.LinkedVehiclelID);
                    table.ForeignKey(
                        name: "FK_LinkedVehicles_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_LinkedVehicles_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_LinkedVehicles_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_LinkedVehicles_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkedVehiclesLinkedVehiclelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Services_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_LinkedVehicles_LinkedVehiclesLinkedVehiclelID",
                        column: x => x.LinkedVehiclesLinkedVehiclelID,
                        principalTable: "LinkedVehicles",
                        principalColumn: "LinkedVehiclelID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ManufacturerID",
                table: "CarModels",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeID",
                table: "Invoices",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserID",
                table: "Invoices",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicles_CustomerID",
                table: "LinkedVehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicles_EmployeeID",
                table: "LinkedVehicles",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicles_InvoiceId",
                table: "LinkedVehicles",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicles_ServiceID",
                table: "LinkedVehicles",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicles_VehicleID",
                table: "LinkedVehicles",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeID",
                table: "Services",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_LinkedVehiclesLinkedVehiclelID",
                table: "Services",
                column: "LinkedVehiclesLinkedVehiclelID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarModelID",
                table: "Vehicles",
                column: "CarModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedVehicles_Services_ServiceID",
                table: "LinkedVehicles",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Manufacturers_ManufacturerID",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Employees_EmployeeID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicles_Employees_EmployeeID",
                table: "LinkedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Employees_EmployeeID",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicles_Customers_CustomerID",
                table: "LinkedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicles_Invoices_InvoiceId",
                table: "LinkedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicles_Services_ServiceID",
                table: "LinkedVehicles");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "LinkedVehicles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}

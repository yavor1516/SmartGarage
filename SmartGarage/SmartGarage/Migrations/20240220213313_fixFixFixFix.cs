using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGarage.Migrations
{
    public partial class fixFixFixFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_LinkedVehicles_LinkedVehicleID",
                table: "LinkedVehicleService");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID",
                table: "LinkedVehicleService");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedVehicleService_LinkedVehicles_LinkedVehicleID",
                table: "LinkedVehicleService",
                column: "LinkedVehicleID",
                principalTable: "LinkedVehicles",
                principalColumn: "LinkedVehicleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID",
                table: "LinkedVehicleService",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_LinkedVehicles_LinkedVehicleID",
                table: "LinkedVehicleService");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID",
                table: "LinkedVehicleService");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedVehicleService_LinkedVehicles_LinkedVehicleID",
                table: "LinkedVehicleService",
                column: "LinkedVehicleID",
                principalTable: "LinkedVehicles",
                principalColumn: "LinkedVehicleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID",
                table: "LinkedVehicleService",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

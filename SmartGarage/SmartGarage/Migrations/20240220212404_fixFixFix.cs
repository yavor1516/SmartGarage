using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGarage.Migrations
{
    public partial class fixFixFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedVehicleServiceID",
                table: "LinkedVehicleService",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LinkedVehicleService",
                newName: "LinkedVehicleServiceID");
        }
    }
}

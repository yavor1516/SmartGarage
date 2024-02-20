using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGarage.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_LinkedVehicles_LinkedVehicleID",
                table: "LinkedVehicleService");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID",
                table: "LinkedVehicleService");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID1",
                table: "LinkedVehicleService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkedVehicleService",
                table: "LinkedVehicleService");

            migrationBuilder.DropIndex(
                name: "IX_LinkedVehicleService_ServiceID1",
                table: "LinkedVehicleService");

            migrationBuilder.DropColumn(
                name: "ServiceID1",
                table: "LinkedVehicleService");

            migrationBuilder.AlterColumn<int>(
                name: "LinkedVehicleServiceID",
                table: "LinkedVehicleService",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkedVehicleService",
                table: "LinkedVehicleService",
                column: "LinkedVehicleServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicleService_LinkedVehicleID",
                table: "LinkedVehicleService",
                column: "LinkedVehicleID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_LinkedVehicles_LinkedVehicleID",
                table: "LinkedVehicleService");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID",
                table: "LinkedVehicleService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkedVehicleService",
                table: "LinkedVehicleService");

            migrationBuilder.DropIndex(
                name: "IX_LinkedVehicleService_LinkedVehicleID",
                table: "LinkedVehicleService");

            migrationBuilder.AlterColumn<int>(
                name: "LinkedVehicleServiceID",
                table: "LinkedVehicleService",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID1",
                table: "LinkedVehicleService",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkedVehicleService",
                table: "LinkedVehicleService",
                columns: new[] { "LinkedVehicleID", "ServiceID" });

            migrationBuilder.CreateIndex(
                name: "IX_LinkedVehicleService_ServiceID1",
                table: "LinkedVehicleService",
                column: "ServiceID1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedVehicleService_Services_ServiceID1",
                table: "LinkedVehicleService",
                column: "ServiceID1",
                principalTable: "Services",
                principalColumn: "ServiceID");
        }
    }
}

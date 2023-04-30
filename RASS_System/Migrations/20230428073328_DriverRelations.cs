using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RASS_System.Migrations
{
    /// <inheritdoc />
    public partial class DriverRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "accidentDataID",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_accidentDataID",
                table: "Drivers",
                column: "accidentDataID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VehicleID",
                table: "Drivers",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Vehicles_VehicleID",
                table: "Drivers",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_accidentDatas_accidentDataID",
                table: "Drivers",
                column: "accidentDataID",
                principalTable: "accidentDatas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Vehicles_VehicleID",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_accidentDatas_accidentDataID",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_accidentDataID",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_VehicleID",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "accidentDataID",
                table: "Drivers");
        }
    }
}

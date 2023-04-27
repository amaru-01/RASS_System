using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RASS_System.Migrations
{
    /// <inheritdoc />
    public partial class Drivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<int>(type: "int", nullable: false),
                    MedicalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentID = table.Column<int>(type: "int", nullable: false),
                    accidentDataID = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drivers_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_accidentDatas_accidentDataID",
                        column: x => x.accidentDataID,
                        principalTable: "accidentDatas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_accidentDataID",
                table: "Drivers",
                column: "accidentDataID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_VehicleID",
                table: "Drivers",
                column: "VehicleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}

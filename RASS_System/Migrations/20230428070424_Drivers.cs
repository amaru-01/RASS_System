using System;
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Conatct = table.Column<int>(type: "int", nullable: false),
                    LicenceNo = table.Column<int>(type: "int", nullable: false),
                    MedicalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentID = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.DropTable(
                name: "Drivers");            
        }
    }
}

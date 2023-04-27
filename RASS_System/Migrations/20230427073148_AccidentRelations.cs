using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RASS_System.Migrations
{
    /// <inheritdoc />
    public partial class AccidentRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_accidentDatas_hospitalID",
                table: "accidentDatas",
                column: "hospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_accidentDatas_policeID",
                table: "accidentDatas",
                column: "policeID");

            migrationBuilder.AddForeignKey(
                name: "FK_accidentDatas_Hospitals_hospitalID",
                table: "accidentDatas",
                column: "hospitalID",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accidentDatas_Polices_policeID",
                table: "accidentDatas",
                column: "policeID",
                principalTable: "Polices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accidentDatas_Hospitals_hospitalID",
                table: "accidentDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_accidentDatas_Polices_policeID",
                table: "accidentDatas");

            migrationBuilder.DropIndex(
                name: "IX_accidentDatas_hospitalID",
                table: "accidentDatas");

            migrationBuilder.DropIndex(
                name: "IX_accidentDatas_policeID",
                table: "accidentDatas");
        }
    }
}

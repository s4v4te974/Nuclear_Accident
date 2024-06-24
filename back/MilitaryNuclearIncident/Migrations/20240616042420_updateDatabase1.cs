using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokenArrowApp.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrokenArrows_VEHICULE_VehiculeId",
                table: "BrokenArrows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VEHICULE",
                table: "VEHICULE");

            migrationBuilder.RenameTable(
                name: "VEHICULE",
                newName: "Vehicule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicule",
                table: "Vehicule",
                column: "VehiculeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrokenArrows_Vehicule_VehiculeId",
                table: "BrokenArrows",
                column: "VehiculeId",
                principalTable: "Vehicule",
                principalColumn: "VehiculeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrokenArrows_Vehicule_VehiculeId",
                table: "BrokenArrows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicule",
                table: "Vehicule");

            migrationBuilder.RenameTable(
                name: "Vehicule",
                newName: "VEHICULE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VEHICULE",
                table: "VEHICULE",
                column: "VehiculeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrokenArrows_VEHICULE_VehiculeId",
                table: "BrokenArrows",
                column: "VehiculeId",
                principalTable: "VEHICULE",
                principalColumn: "VehiculeId");
        }
    }
}

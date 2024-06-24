using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokenArrowApp.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VEHICULE",
                columns: table => new
                {
                    VehiculeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Builder = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    VehiculeDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICULE", x => x.VehiculeId);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Builder = table.Column<string>(type: "text", nullable: true),
                    WeaponDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "BrokenArrows",
                columns: table => new
                {
                    BrokenArrowId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoordonateId = table.Column<Guid>(type: "uuid", nullable: true),
                    FullDescriptionId = table.Column<Guid>(type: "uuid", nullable: true),
                    VehiculeId = table.Column<Guid>(type: "uuid", nullable: false),
                    WeaponId = table.Column<Guid>(type: "uuid", nullable: true),
                    DisasterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    BubbleDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokenArrows", x => x.BrokenArrowId);
                    table.ForeignKey(
                        name: "FK_BrokenArrows_VEHICULE_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "VEHICULE",
                        principalColumn: "VehiculeId");
                    table.ForeignKey(
                        name: "FK_BrokenArrows_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "WeaponId");
                });

            migrationBuilder.CreateTable(
                name: "Coordonate",
                columns: table => new
                {
                    CoordonateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryName = table.Column<string>(type: "text", nullable: true),
                    PositionLost = table.Column<string>(type: "text", nullable: true),
                    XCoordonate = table.Column<float>(type: "real", nullable: true),
                    YCoordonate = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordonate", x => x.CoordonateId);
                    table.ForeignKey(
                        name: "FK_Coordonate_BrokenArrows_CoordonateId",
                        column: x => x.CoordonateId,
                        principalTable: "BrokenArrows",
                        principalColumn: "BrokenArrowId");
                });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    FullDescriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.FullDescriptionId);
                    table.ForeignKey(
                        name: "FK_Description_BrokenArrows_FullDescriptionId",
                        column: x => x.FullDescriptionId,
                        principalTable: "BrokenArrows",
                        principalColumn: "BrokenArrowId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrokenArrows_VehiculeId",
                table: "BrokenArrows",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_BrokenArrows_WeaponId",
                table: "BrokenArrows",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordonate");

            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropTable(
                name: "BrokenArrows");

            migrationBuilder.DropTable(
                name: "VEHICULE");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bs.Data.Migrations
{
    public partial class Uno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentName = table.Column<string>(type: "varchar(30)", nullable: false),
                    TownName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Locations = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    AgencyName = table.Column<string>(type: "varchar(50)", nullable: false),
                    AgencyType = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.AgencyId);
                    table.ForeignKey(
                        name: "FK_Agencies_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uninterruptibles",
                columns: table => new
                {
                    UpsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    UpsName = table.Column<string>(type: "varchar(30)", nullable: false),
                    UpsModel = table.Column<string>(type: "varchar(50)", nullable: false),
                    UpsPower = table.Column<float>(type: "real", nullable: false),
                    UpsManageable = table.Column<bool>(type: "bit", nullable: false),
                    UpsModules = table.Column<int>(type: "int", nullable: false),
                    UpsBatteries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uninterruptibles", x => x.UpsId);
                    table.ForeignKey(
                        name: "FK_Uninterruptibles_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryChanges",
                columns: table => new
                {
                    BatteryChangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    UpsId = table.Column<int>(type: "int", nullable: false),
                    BatteryChangeDate = table.Column<DateTime>(type: "date", nullable: false),
                    BatteryChangeComments = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    ModulesInst = table.Column<int>(type: "int", nullable: false),
                    BatteriesInst = table.Column<int>(type: "int", nullable: false),
                    BatteryChangeNext = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryChanges", x => x.BatteryChangeId);
                    table.ForeignKey(
                        name: "FK_BatteryChanges_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "AgencyId",
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryChanges_Uninterruptibles_UpsId",
                        column: x => x.UpsId,
                        principalTable: "Uninterruptibles",
                        principalColumn: "UpsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_LocationId",
                table: "Agencies",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryChanges_AgencyId",
                table: "BatteryChanges",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryChanges_UpsId",
                table: "BatteryChanges",
                column: "UpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Uninterruptibles_AgencyId",
                table: "Uninterruptibles",
                column: "AgencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryChanges");

            migrationBuilder.DropTable(
                name: "Uninterruptibles");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Locations");
            
        }
    }
}

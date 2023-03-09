using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bs.Data.Migrations
{
    public partial class Cinco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpsIpAddress",
                table: "Uninterruptibles",
                type: "string",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpsIpAddress",
                table: "Uninterruptibles");
        }
    }
}

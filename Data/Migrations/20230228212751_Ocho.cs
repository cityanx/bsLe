using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bs.Data.Migrations
{
    public partial class Ocho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpsLimit",
                table: "Uninterruptibles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpsLimit",
                table: "Uninterruptibles");
        }
    }
}

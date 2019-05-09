using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBnBV5.Data.Migrations
{
    public partial class addTestString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testString",
                table: "Calendar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testString",
                table: "Calendar");
        }
    }
}

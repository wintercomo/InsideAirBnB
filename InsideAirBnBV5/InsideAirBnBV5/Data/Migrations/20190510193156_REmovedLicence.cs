using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBnBV5.Data.Migrations
{
    public partial class REmovedLicence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "License",
                table: "Listings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Listings",
                nullable: true);
        }
    }
}

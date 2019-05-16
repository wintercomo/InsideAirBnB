using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirbnb.Migrations
{
    public partial class RemovedLoginTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calendar");

            migrationBuilder.DropTable(
                name: "neighbourhoods");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "summary-listings");

            migrationBuilder.DropTable(
                name: "summary-reviews");

            migrationBuilder.DropTable(
                name: "listings");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBnBV5.Data.Migrations
{
    public partial class AddedScafolding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Neighbourhoods");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SummaryListings");

            migrationBuilder.DropTable(
                name: "SummaryReviews");

            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}

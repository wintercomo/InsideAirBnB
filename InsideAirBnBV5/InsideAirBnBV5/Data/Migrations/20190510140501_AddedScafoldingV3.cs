using Microsoft.EntityFrameworkCore.Migrations;

namespace InsideAirBnBV5.Data.Migrations
{
    public partial class AddedScafoldingV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "testString",
                table: "Calendar",
                newName: "TestString");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestString",
                table: "Calendar",
                newName: "testString");
        }
    }
}

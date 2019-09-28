using Microsoft.EntityFrameworkCore.Migrations;

namespace RZHD.Migrations
{
    public partial class trainuniquenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trains_Number",
                table: "Trains",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trains_Number",
                table: "Trains");
        }
    }
}

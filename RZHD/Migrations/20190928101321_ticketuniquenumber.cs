using Microsoft.EntityFrameworkCore.Migrations;

namespace RZHD.Migrations
{
    public partial class ticketuniquenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Number",
                table: "Tickets",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_Number",
                table: "Tickets");
        }
    }
}

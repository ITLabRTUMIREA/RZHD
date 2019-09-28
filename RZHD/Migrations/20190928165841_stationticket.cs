using Microsoft.EntityFrameworkCore.Migrations;

namespace RZHD.Migrations
{
    public partial class stationticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Tickets_TicketId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_TicketId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Stations");

            migrationBuilder.CreateTable(
                name: "StationTickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationTickets", x => new { x.StationId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_StationTickets_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StationTickets_TicketId",
                table: "StationTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationTickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Stations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_TicketId",
                table: "Stations",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Tickets_TicketId",
                table: "Stations",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

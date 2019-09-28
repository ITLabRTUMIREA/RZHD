using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RZHD.Migrations
{
    public partial class ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Stations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArriveTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Tickets_TicketId",
                table: "Stations");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Stations_TicketId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Stations");
        }
    }
}

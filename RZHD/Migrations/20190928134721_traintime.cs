using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RZHD.Migrations
{
    public partial class traintime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArriveTIme",
                table: "Trains",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Trains",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArriveTIme",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Trains");
        }
    }
}

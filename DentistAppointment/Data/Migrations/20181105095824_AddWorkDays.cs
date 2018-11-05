using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAppointment.Data.Migrations
{
    public partial class AddWorkDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WorkDays",
                table: "Dentists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "Dentists");
        }
    }
}

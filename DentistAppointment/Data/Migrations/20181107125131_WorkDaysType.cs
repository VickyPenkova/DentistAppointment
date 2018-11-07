using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAppointment.Data.Migrations
{
    public partial class WorkDaysType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "Dentists");
            migrationBuilder.AddColumn<int>(
                name: "WorkDays",
                table: "Dentists",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkDays",
                table: "Dentists");
            migrationBuilder.AddColumn<int>(
                name: "WorkDays",
                table: "Dentists",
                nullable: false);
        }
    }
}

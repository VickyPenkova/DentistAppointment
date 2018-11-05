using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAppointment.Data.Migrations
{
    public partial class ReservationDentistIdRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Dentists_DentistId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DentistId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DentistId1",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DentistId",
                table: "Reservations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "DentistId1",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DentistId1",
                table: "Reservations",
                column: "DentistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Dentists_DentistId1",
                table: "Reservations",
                column: "DentistId1",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

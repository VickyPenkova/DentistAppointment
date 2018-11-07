using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAppointment.Data.Migrations
{
    public partial class NullableDentistId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Dentists_DentistId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Dentists_DentistId",
                table: "AspNetUsers",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Dentists_DentistId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Dentists_DentistId",
                table: "AspNetUsers",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

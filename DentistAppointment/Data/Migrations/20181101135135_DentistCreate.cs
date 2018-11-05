using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAppointment.Data.Migrations
{
    public partial class DentistCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DentistForeignKey",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dentists",
                columns: table => new
                {
                    DentistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    WorkTimeStart = table.Column<DateTime>(nullable: false),
                    WorkTimeEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentists", x => x.DentistId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DentistForeignKey",
                table: "AspNetUsers",
                column: "DentistForeignKey",
                unique: true,
                filter: "[DentistForeignKey] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Dentists_DentistForeignKey",
                table: "AspNetUsers",
                column: "DentistForeignKey",
                principalTable: "Dentists",
                principalColumn: "DentistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Dentists_DentistForeignKey",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Dentists");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DentistForeignKey",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DentistForeignKey",
                table: "AspNetUsers");
        }
    }
}

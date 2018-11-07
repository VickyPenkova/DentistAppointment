using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistAppointment.Data.Migrations
{
    public partial class BlacklistedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BlacklistedId",
                table: "Blacklist",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blacklist_BlacklistedId",
                table: "Blacklist",
                column: "BlacklistedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blacklist_AspNetUsers_BlacklistedId",
                table: "Blacklist",
                column: "BlacklistedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blacklist_AspNetUsers_BlacklistedId",
                table: "Blacklist");

            migrationBuilder.DropIndex(
                name: "IX_Blacklist_BlacklistedId",
                table: "Blacklist");

            migrationBuilder.AlterColumn<string>(
                name: "BlacklistedId",
                table: "Blacklist",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

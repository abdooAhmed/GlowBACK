using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Data.Migrations
{
    public partial class DynamicTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DynamicTest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicTest_UserId",
                table: "DynamicTest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicTest_AspNetUsers_UserId",
                table: "DynamicTest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicTest_AspNetUsers_UserId",
                table: "DynamicTest");

            migrationBuilder.DropIndex(
                name: "IX_DynamicTest_UserId",
                table: "DynamicTest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DynamicTest");
        }
    }
}

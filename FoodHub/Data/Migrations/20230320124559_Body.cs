using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Data.Migrations
{
    public partial class Body : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyCircumferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoulderCircumference = table.Column<float>(type: "real", nullable: false),
                    ArmCircumference = table.Column<float>(type: "real", nullable: false),
                    ThighCircumference = table.Column<float>(type: "real", nullable: false),
                    QuailCircumference = table.Column<float>(type: "real", nullable: false),
                    WaistCircumference = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyCircumferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyCircumferences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyCircumferences_UserId",
                table: "BodyCircumferences",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyCircumferences");
        }
    }
}

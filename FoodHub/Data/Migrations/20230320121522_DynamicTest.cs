using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Data.Migrations
{
    public partial class DynamicTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Circumduction = table.Column<bool>(type: "bit", nullable: false),
                    Kyphosis = table.Column<bool>(type: "bit", nullable: false),
                    Lordosis = table.Column<bool>(type: "bit", nullable: false),
                    Scoliosis = table.Column<bool>(type: "bit", nullable: false),
                    Shulder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicTest", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicTest");
        }
    }
}

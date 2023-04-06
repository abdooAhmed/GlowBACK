using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.Data.Migrations
{
    public partial class FitnessTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmFirstSit = table.Column<int>(type: "int", nullable: false),
                    ArmSecondSit = table.Column<int>(type: "int", nullable: false),
                    ArmThirdSit = table.Column<int>(type: "int", nullable: false),
                    CurlUpFirstSit = table.Column<int>(type: "int", nullable: false),
                    CurlUpSecondSit = table.Column<int>(type: "int", nullable: false),
                    CurlUpThirdSit = table.Column<int>(type: "int", nullable: false),
                    ModifiedFirstSit = table.Column<int>(type: "int", nullable: false),
                    ModifiedSecondSit = table.Column<int>(type: "int", nullable: false),
                    ModifiedThirdSit = table.Column<int>(type: "int", nullable: false),
                    PushUpFirstSit = table.Column<int>(type: "int", nullable: false),
                    PushUpSecondSit = table.Column<int>(type: "int", nullable: false),
                    PushUpThirdSit = table.Column<int>(type: "int", nullable: false),
                    PlankFirstSit = table.Column<int>(type: "int", nullable: false),
                    PlankSecondSit = table.Column<int>(type: "int", nullable: false),
                    PlankThirdSit = table.Column<int>(type: "int", nullable: false),
                    SidePlankFirstSit = table.Column<int>(type: "int", nullable: false),
                    SidePlankSecondSit = table.Column<int>(type: "int", nullable: false),
                    SidePlankThirdSit = table.Column<int>(type: "int", nullable: false),
                    WallSetFirstSit = table.Column<int>(type: "int", nullable: false),
                    WallSetSecondSit = table.Column<int>(type: "int", nullable: false),
                    WallSetThirdSit = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessTests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessTests_UserId",
                table: "FitnessTests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessTests");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class hashtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hashtag",
                columns: table => new
                {
                    InsightId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtag", x => new { x.InsightId, x.Id });
                    table.ForeignKey(
                        name: "FK_Hashtag_Insight_InsightId",
                        column: x => x.InsightId,
                        principalTable: "Insight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hashtag");
        }
    }
}

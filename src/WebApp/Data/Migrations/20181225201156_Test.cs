using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestProperty",
                table: "MarkdownPosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestProperty",
                table: "MarkdownPosts");
        }
    }
}

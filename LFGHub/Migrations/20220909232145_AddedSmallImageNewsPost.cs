using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LFGHub.Migrations
{
    public partial class AddedSmallImageNewsPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmallImageUrl",
                table: "NewsPosts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmallImageUrl",
                table: "NewsPosts");
        }
    }
}

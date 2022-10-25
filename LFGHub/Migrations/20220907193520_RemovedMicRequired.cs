using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LFGHub.Migrations
{
    public partial class RemovedMicRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MicRequired",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MicRequired",
                table: "Posts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}

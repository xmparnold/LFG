using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LFGHub.Migrations
{
    public partial class ReaddedGameActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameActivityId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameActivities",
                columns: table => new
                {
                    GameActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    MinPlayers = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameActivities", x => x.GameActivityId);
                    table.ForeignKey(
                        name: "FK_GameActivities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GameActivityId",
                table: "Posts",
                column: "GameActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GameActivities_UserId",
                table: "GameActivities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts",
                column: "GameActivityId",
                principalTable: "GameActivities",
                principalColumn: "GameActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "GameActivities");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GameActivityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GameActivityId",
                table: "Posts");
        }
    }
}

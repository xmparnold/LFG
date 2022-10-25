using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LFGHub.Migrations
{
    public partial class AddedGameActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameActivities",
                table: "GameActivities");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "GameActivities",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GameActivities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "GameActivityId",
                table: "GameActivities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameActivities",
                table: "GameActivities",
                column: "GameActivityId");

            migrationBuilder.CreateTable(
                name: "NewsPosts",
                columns: table => new
                {
                    NewsPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subtitle = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPosts", x => x.NewsPostId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GameActivities_UserId",
                table: "GameActivities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameActivities_Users_UserId",
                table: "GameActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts",
                column: "GameActivityId",
                principalTable: "GameActivities",
                principalColumn: "GameActivityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameActivities_Users_UserId",
                table: "GameActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "NewsPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameActivities",
                table: "GameActivities");

            migrationBuilder.DropIndex(
                name: "IX_GameActivities_UserId",
                table: "GameActivities");

            migrationBuilder.DropColumn(
                name: "GameActivityId",
                table: "GameActivities");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GameActivities",
                newName: "ActivityId");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "GameActivities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameActivities",
                table: "GameActivities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts",
                column: "GameActivityId",
                principalTable: "GameActivities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

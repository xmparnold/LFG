using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LFGHub.Migrations
{
    public partial class TotallyFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Activities_GameActivityId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "GameActivities");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_GameActivities_GameActivityId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameActivities",
                table: "GameActivities");

            migrationBuilder.RenameTable(
                name: "GameActivities",
                newName: "Activities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Activities_GameActivityId",
                table: "Posts",
                column: "GameActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

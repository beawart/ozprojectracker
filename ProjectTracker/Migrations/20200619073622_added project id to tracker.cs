using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTracker.Migrations
{
    public partial class addedprojectidtotracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "Trackers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trackers_ProjectTypeId",
                table: "Trackers",
                column: "ProjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trackers_Projects_ProjectTypeId",
                table: "Trackers",
                column: "ProjectTypeId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trackers_Projects_ProjectTypeId",
                table: "Trackers");

            migrationBuilder.DropIndex(
                name: "IX_Trackers_ProjectTypeId",
                table: "Trackers");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "Trackers");
        }
    }
}

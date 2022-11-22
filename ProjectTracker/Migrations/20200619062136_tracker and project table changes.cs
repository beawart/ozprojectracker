using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTracker.Migrations
{
    public partial class trackerandprojecttablechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "counter",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createdOn",
                table: "Projects",
                newName: "CreatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Projects",
                newName: "createdOn");

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "Trackers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "counter",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}

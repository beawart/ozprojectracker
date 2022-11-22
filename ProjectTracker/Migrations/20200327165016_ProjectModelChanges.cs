using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTracker.Migrations
{
    public partial class ProjectModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "ProjectTypes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProjectTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProjectTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectTypes");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "ProjectTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

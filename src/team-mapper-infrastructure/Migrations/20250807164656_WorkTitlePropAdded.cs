using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkTitlePropAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "WorkItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ExpiringWorkItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ExpiringWorkItems");
        }
    }
}

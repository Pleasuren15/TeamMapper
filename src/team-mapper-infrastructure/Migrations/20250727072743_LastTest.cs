using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LastTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "WorkItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems",
                column: "WorkItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems");

            migrationBuilder.RenameTable(
                name: "WorkItems",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "WorkItemId");
        }
    }
}

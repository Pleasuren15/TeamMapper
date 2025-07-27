using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaskRenamed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "WorkItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkItemId",
                table: "Tasks",
                newName: "TaskId");
        }
    }
}

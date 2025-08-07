using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpiringWorkItemModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpiringWorkItems",
                columns: table => new
                {
                    ExpiringWorkItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotificationSent = table.Column<bool>(type: "bit", nullable: false),
                    WorkItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiringWorkItems", x => x.ExpiringWorkItemId);
                    table.ForeignKey(
                        name: "FK_ExpiringWorkItems_WorkItems_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItems",
                        principalColumn: "WorkItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpiringWorkItems_WorkItemId",
                table: "ExpiringWorkItems",
                column: "WorkItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpiringWorkItems");
        }
    }
}

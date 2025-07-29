using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkItemFKImplemented : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamMemberId",
                table: "WorkItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    TeamMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.TeamMemberId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_TeamMemberId",
                table: "WorkItems",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_TeamMember_TeamMemberId",
                table: "WorkItems",
                column: "TeamMemberId",
                principalTable: "TeamMember",
                principalColumn: "TeamMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_TeamMember_TeamMemberId",
                table: "WorkItems");

            migrationBuilder.DropTable(
                name: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_WorkItems_TeamMemberId",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "WorkItems");
        }
    }
}

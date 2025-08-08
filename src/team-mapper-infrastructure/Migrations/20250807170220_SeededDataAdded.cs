using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_TeamMember_TeamMemberId",
                table: "WorkItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.RenameTable(
                name: "TeamMember",
                newName: "TeamMembers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "TeamMemberId");

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMemberId", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("53348d0a-30b6-47b4-b385-0c0cc686350b"), "BridgetCraf@gmail.com", "Bridget Craft" },
                    { new Guid("6b29b98d-dd9f-4d05-9519-224eb1010729"), "CassyJohnson@gmail.com", "Cassy Johnson" },
                    { new Guid("6c7adab1-b9f5-45d4-a54c-d5e6b7e8a479"), "PleasureNdhlovu@gmail.com", "Pleasure Ndhlovu" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_TeamMembers_TeamMemberId",
                table: "WorkItems",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "TeamMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_TeamMembers_TeamMemberId",
                table: "WorkItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("53348d0a-30b6-47b4-b385-0c0cc686350b"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("6b29b98d-dd9f-4d05-9519-224eb1010729"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("6c7adab1-b9f5-45d4-a54c-d5e6b7e8a479"));

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "TeamMember");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_TeamMember_TeamMemberId",
                table: "WorkItems",
                column: "TeamMemberId",
                principalTable: "TeamMember",
                principalColumn: "TeamMemberId");
        }
    }
}

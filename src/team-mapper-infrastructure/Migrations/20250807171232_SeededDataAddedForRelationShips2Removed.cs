using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataAddedForRelationShips2Removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMemberId", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "PleasureNdhlovu@gmail.com", "Pleasure Ndhlovu" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), "CassyJohnson@gmail.com", "Cassy Johnson" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), "BridgetCraf@gmail.com", "Bridget Craft" }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "Description", "EndDate", "IsComplete", "TaskCategory", "TaskPriority", "TeamMemberId", "Title" },
                values: new object[,]
                {
                    { new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"), "Description 1", new DateTime(2025, 8, 14, 19, 9, 58, 136, DateTimeKind.Local).AddTicks(4238), false, 50, 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Task1" },
                    { new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"), "Description 2", new DateTime(2025, 8, 14, 19, 9, 58, 138, DateTimeKind.Local).AddTicks(6617), false, 50, 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), "Task2" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Description 3", new DateTime(2025, 8, 14, 19, 9, 58, 138, DateTimeKind.Local).AddTicks(6648), false, 50, 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), "Task3" }
                });
        }
    }
}

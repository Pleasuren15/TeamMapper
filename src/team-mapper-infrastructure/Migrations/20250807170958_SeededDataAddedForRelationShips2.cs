using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace team_mapper_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataAddedForRelationShips2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: new Guid("45e703cf-e0f5-4abe-92f9-da11826ba970"));

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: new Guid("992e1a93-ac1f-420b-a149-980ee50facf8"));

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: new Guid("a4d85bb2-d17b-4c83-9cde-ad9f22df0d8d"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("8637fd54-1658-415b-ad8e-3c504e96daf6"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("e28e1a24-dc37-4872-b33c-387b3bede142"));

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: new Guid("ef80abdd-c438-4f32-8fd2-5699f17a962b"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMemberId", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("8637fd54-1658-415b-ad8e-3c504e96daf6"), "BridgetCraf@gmail.com", "Bridget Craft" },
                    { new Guid("e28e1a24-dc37-4872-b33c-387b3bede142"), "PleasureNdhlovu@gmail.com", "Pleasure Ndhlovu" },
                    { new Guid("ef80abdd-c438-4f32-8fd2-5699f17a962b"), "CassyJohnson@gmail.com", "Cassy Johnson" }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "Description", "EndDate", "IsComplete", "TaskCategory", "TaskPriority", "TeamMemberId", "Title" },
                values: new object[,]
                {
                    { new Guid("45e703cf-e0f5-4abe-92f9-da11826ba970"), "Description 2", new DateTime(2025, 8, 14, 19, 6, 30, 445, DateTimeKind.Local).AddTicks(1561), false, 50, 0, new Guid("ef80abdd-c438-4f32-8fd2-5699f17a962b"), "Task2" },
                    { new Guid("992e1a93-ac1f-420b-a149-980ee50facf8"), "Description 3", new DateTime(2025, 8, 14, 19, 6, 30, 445, DateTimeKind.Local).AddTicks(1582), false, 50, 0, new Guid("8637fd54-1658-415b-ad8e-3c504e96daf6"), "Task3" },
                    { new Guid("a4d85bb2-d17b-4c83-9cde-ad9f22df0d8d"), "Description 1", new DateTime(2025, 8, 14, 19, 6, 30, 443, DateTimeKind.Local).AddTicks(1115), false, 50, 0, new Guid("e28e1a24-dc37-4872-b33c-387b3bede142"), "Task1" }
                });
        }
    }
}

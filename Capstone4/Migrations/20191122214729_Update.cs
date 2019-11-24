using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Day_29___Identity_Framework.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Complete", "Description", "DueDate", "UserId" },
                values: new object[] { 1, false, "lol", new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "06554c8c-9508-449d-bcb0-93d5e638adb4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultRolesAndCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "264e25b7-6924-4cb4-aa9f-020ad53ef821", "5322123f-bb76-44e0-9472-4e3ca81918aa", "Administrator", "ADMINISTRATOR" },
                    { "8f805e2b-a44d-4a1b-b491-0d8f4175e981", "51a1ec45-daf9-4621-8585-fb371dea6887", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "created_by", "created_date", "credits", "modified_by", "modified_date", "title" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minimal API Development" },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultimate API Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "264e25b7-6924-4cb4-aa9f-020ad53ef821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "8f805e2b-a44d-4a1b-b491-0d8f4175e981");

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}

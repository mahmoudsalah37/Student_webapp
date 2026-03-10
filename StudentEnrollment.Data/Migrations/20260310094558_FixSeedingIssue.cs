using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedingIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "264e25b7-6924-4cb4-aa9f-020ad53ef821",
                column: "user_name",
                value: "School User");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "8f805e2b-a44d-4a1b-b491-0d8f4175e981",
                column: "user_name",
                value: "School Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "264e25b7-6924-4cb4-aa9f-020ad53ef821",
                column: "user_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "8f805e2b-a44d-4a1b-b491-0d8f4175e981",
                column: "user_name",
                value: null);
        }
    }
}

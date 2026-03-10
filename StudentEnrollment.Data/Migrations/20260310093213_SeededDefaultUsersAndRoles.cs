using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_birth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "date_of_birth", "email", "email_confirmed", "first_name", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { "264e25b7-6924-4cb4-aa9f-020ad53ef821", 0, "68703f9a-efc5-4f2b-aedd-7e498c7a549f", null, "schooluser@localhost.com", true, "School", "User", false, null, "SCHOOLUSER@LOCALHOST.COM", "SCHOOLUSER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBCqeyy/X1ADwTUMyjX1YATArcBE3cviRfZzYtu3Cz4oNzqeTA312ea5qhJtq0rEvg==", null, false, "9bda1367-8d1d-4509-900b-ecf2b1ff6873", false, null },
                    { "8f805e2b-a44d-4a1b-b491-0d8f4175e981", 0, "d59eaa62-98fa-40d8-8353-c6c3d6c1a86b", null, "schooladmin@localhost.com", true, "School", "Admin", false, null, "SCHOOLADMIN@LOCALHOST.COM", "SCHOOLADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOppS140pm1QK0e1a9EaCMy+7mwCa24VwpnZqo/aaemvPQsiCfUW/28UejSaRHE3sg==", null, false, "18a72843-04ad-498f-aa40-36bb4edf804e", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { "8f805e2b-a44d-4a1b-b491-0d8f4175e981", "264e25b7-6924-4cb4-aa9f-020ad53ef821" },
                    { "264e25b7-6924-4cb4-aa9f-020ad53ef821", "8f805e2b-a44d-4a1b-b491-0d8f4175e981" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "8f805e2b-a44d-4a1b-b491-0d8f4175e981", "264e25b7-6924-4cb4-aa9f-020ad53ef821" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "264e25b7-6924-4cb4-aa9f-020ad53ef821", "8f805e2b-a44d-4a1b-b491-0d8f4175e981" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "264e25b7-6924-4cb4-aa9f-020ad53ef821");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "8f805e2b-a44d-4a1b-b491-0d8f4175e981");

            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "AspNetUsers");
        }
    }
}

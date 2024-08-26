using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticlesPOSTGREDBCRUDOperations.Migrations
{
    /// <inheritdoc />
    public partial class UserTableCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 19, 29, 662, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 19, 29, 662, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "password2", "test2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 18, 6, 692, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 18, 6, 692, DateTimeKind.Utc).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "password", "test" });
        }
    }
}

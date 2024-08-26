using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticlesPOSTGREDBCRUDOperations.Migrations
{
    /// <inheritdoc />
    public partial class UserTableAddPasswordColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 42, 17, 991, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 42, 17, 991, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tz.wk9z5N.nxOcih2yRdzutfbGmxL9C4rHURbB3tXR3AbZxAeHQsq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$mZ3w2GCiNM8bLswR0iipUusvuYFmdPSOk2ejD3eU6TfcjAzvhsbLS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

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
        }
    }
}

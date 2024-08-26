using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticlesPOSTGREDBCRUDOperations.Migrations
{
    /// <inheritdoc />
    public partial class UserTableColumnNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 48, 35, 130, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 26, 14, 48, 35, 130, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rihoS60h2FSl/Sta/LwYluV7hauS/ggMuvCnvUmCeWOnbUL1zul2W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$.IN/CpWTdzh..aMQNBhIvOb/NHp1C9bI/5kmf6msfV9VSJPMq79IS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
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
                columns: new[] { "Password", "PasswordHash" },
                values: new object[] { "password", "$2a$11$tz.wk9z5N.nxOcih2yRdzutfbGmxL9C4rHURbB3tXR3AbZxAeHQsq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "PasswordHash" },
                values: new object[] { "password2", "$2a$11$mZ3w2GCiNM8bLswR0iipUusvuYFmdPSOk2ejD3eU6TfcjAzvhsbLS" });
        }
    }
}

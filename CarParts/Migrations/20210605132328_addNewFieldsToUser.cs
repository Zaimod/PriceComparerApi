using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class addNewFieldsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82518825-557d-47e0-ab67-6e228d6255d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84cb2235-7bab-49fd-9ce1-5b3b4b8b3c38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d09cf83c-423d-49dd-a97f-5b992ede8566");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99e0d328-9b40-468b-81ea-0ee63e28a0b7", "47a3c75b-d321-4619-98b9-0f4451016681", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2eff913a-226a-4583-a0e1-7c2a0150895c", "4b7295eb-f564-41cd-b180-b21270ae1dca", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5efb9d41-e820-415e-98d1-b7f50559767c", "ebdd9fbc-5875-487b-944d-d66844d7a634", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eff913a-226a-4583-a0e1-7c2a0150895c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5efb9d41-e820-415e-98d1-b7f50559767c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99e0d328-9b40-468b-81ea-0ee63e28a0b7");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82518825-557d-47e0-ab67-6e228d6255d1", "d622a12f-3f81-495d-af48-100e8d931112", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d09cf83c-423d-49dd-a97f-5b992ede8566", "225e8fa4-e707-45b1-930a-f638f5be2330", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84cb2235-7bab-49fd-9ce1-5b3b4b8b3c38", "037b1a84-c17e-4293-83c4-302d4e669666", "User", "USER" });
        }
    }
}

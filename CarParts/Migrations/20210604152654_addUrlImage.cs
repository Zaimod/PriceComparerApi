using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class addUrlImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "165b186d-1ded-487d-bb21-3bb4f5a083a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "761fdc82-b653-4427-ba02-6b6c62cffc8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba1f15a4-cfe0-46b1-9dfe-ff288da568e2");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Category",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Category");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba1f15a4-cfe0-46b1-9dfe-ff288da568e2", "48d73ab7-48c4-422e-b3cb-45137881b973", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "165b186d-1ded-487d-bb21-3bb4f5a083a4", "45a7936a-cd06-4451-b87f-9813e5da0f1f", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "761fdc82-b653-4427-ba02-6b6c62cffc8b", "6d967c1d-cfce-4a42-aca8-caaa62228bbd", "User", "USER" });
        }
    }
}

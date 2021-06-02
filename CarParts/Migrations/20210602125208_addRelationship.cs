using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class addRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "051e6287-ab3d-4246-a56b-9a127b6b0368");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7098dc5a-cdf7-4980-964a-5676b7f7e43f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d371314-b300-4abf-a0b1-a9a79eba5b41");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_categoryId",
                table: "Product");

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

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Product");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d371314-b300-4abf-a0b1-a9a79eba5b41", "f59bcfb4-2c77-4e29-b978-f26597c80ae6", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7098dc5a-cdf7-4980-964a-5676b7f7e43f", "6f5499dc-56ae-42f0-aa30-7fe58f8cd103", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "051e6287-ab3d-4246-a56b-9a127b6b0368", "621ef929-832b-41df-9c66-ef6b9f320a47", "User", "USER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class addNewFieldForProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b8629ff-9d43-4e4b-81b1-e5155768df09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53f32d9f-c0e5-4269-b4f8-798037255228");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6baf7707-9216-4cab-a182-2fd983745b95");

            migrationBuilder.AddColumn<int>(
                name: "numbReviews",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "numbReviews",
                table: "Product");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6baf7707-9216-4cab-a182-2fd983745b95", "0ac6f222-6956-4c46-b2bd-a027b51cf8e2", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b8629ff-9d43-4e4b-81b1-e5155768df09", "828bad12-1107-42bc-82e9-6ad2152cb880", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53f32d9f-c0e5-4269-b4f8-798037255228", "e65b32b1-7725-4afd-b415-fb5f05895b02", "User", "USER" });
        }
    }
}

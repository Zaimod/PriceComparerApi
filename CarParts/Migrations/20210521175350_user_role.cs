using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class user_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "632b03ac-ac1a-4e96-8953-5cd42148f456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a1118b0-6104-4855-b8ef-a776ed4be86d");

            migrationBuilder.AddColumn<string>(
                name: "exclude",
                table: "Product",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "exclude",
                table: "Product");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "632b03ac-ac1a-4e96-8953-5cd42148f456", "8b9a3fb1-d04e-48d1-a3b3-53aed141734e", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a1118b0-6104-4855-b8ef-a776ed4be86d", "20e7ccdf-607b-4b0e-bdfa-a2a3b8d38a44", "Administrator", "ADMINISTRATOR" });
        }
    }
}

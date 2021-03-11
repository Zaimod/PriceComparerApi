using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03694a8e-de00-4352-8c0a-52fdd2a93e2c", "ffc5a89d-ac55-4dcb-b5bd-386f7ff74e04", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f70fbaa0-ef2b-4dc5-acb1-b3588d8b0e4d", "26ce02ac-6923-4a6b-9efd-e805f4da40ce", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03694a8e-de00-4352-8c0a-52fdd2a93e2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f70fbaa0-ef2b-4dc5-acb1-b3588d8b0e4d");
        }
    }
}

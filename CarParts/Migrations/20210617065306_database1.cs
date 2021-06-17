using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceComparer.Migrations
{
    public partial class database1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteItem_AspNetUsers_UserId",
                table: "FavouriteItem");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteItem_UserId",
                table: "FavouriteItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64631636-a2eb-4d4d-8dfb-619f39fbf408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2ed025-9734-4104-88a6-f6d138bbdc7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88a0ba6d-64cf-485b-8a15-a8c4a535f61a");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavouriteItem");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2a19969-49d2-44e4-8871-821106eac35f", "f71a15e6-ecfc-4f83-a730-dc32555ee0a3", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f313cf2-cd0a-4800-a2cc-2c5f39481f4e", "ae58b200-8ad6-40c2-adb2-e87606ffa0fc", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98dbde22-7cb2-459d-8dc5-e0ffa2613b10", "2e14a5ec-d10f-47d5-be85-b5877c00b161", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteItem_catalogId",
                table: "FavouriteItem",
                column: "catalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteItem_Catalog_catalogId",
                table: "FavouriteItem",
                column: "catalogId",
                principalTable: "Catalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteItem_Catalog_catalogId",
                table: "FavouriteItem");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteItem_catalogId",
                table: "FavouriteItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f313cf2-cd0a-4800-a2cc-2c5f39481f4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98dbde22-7cb2-459d-8dc5-e0ffa2613b10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2a19969-49d2-44e4-8871-821106eac35f");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavouriteItem",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64631636-a2eb-4d4d-8dfb-619f39fbf408", "47509004-c87c-418f-a540-b0fc3cc53deb", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88a0ba6d-64cf-485b-8a15-a8c4a535f61a", "2d3b49ec-b047-4d92-9cd6-fc98c204127c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b2ed025-9734-4104-88a6-f6d138bbdc7b", "5a22f267-c50b-457a-b681-b566a8e779bb", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteItem_UserId",
                table: "FavouriteItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteItem_AspNetUsers_UserId",
                table: "FavouriteItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

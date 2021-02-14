using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class CreateDatabaseFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_cars_CarsId",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_CarsId",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "CarsId",
                table: "suppliers");

            migrationBuilder.CreateTable(
                name: "CarsSuppliers",
                columns: table => new
                {
                    CarsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SuppliersId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsSuppliers", x => new { x.CarsId, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_CarsSuppliers_cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "cars",
                        principalColumn: "CarsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarsSuppliers_suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsSuppliers_SuppliersId",
                table: "CarsSuppliers",
                column: "SuppliersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsSuppliers");

            migrationBuilder.AddColumn<Guid>(
                name: "CarsId",
                table: "suppliers",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_CarsId",
                table: "suppliers",
                column: "CarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_cars_CarsId",
                table: "suppliers",
                column: "CarsId",
                principalTable: "cars",
                principalColumn: "CarsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

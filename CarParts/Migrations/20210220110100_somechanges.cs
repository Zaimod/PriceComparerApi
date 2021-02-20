using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParts.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    CarsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Brand = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.CarsId);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierId);
                });

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

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    PartsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CarsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SuppliersId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.PartsId);
                    table.ForeignKey(
                        name: "FK_parts_cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "cars",
                        principalColumn: "CarsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parts_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parts_suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsSuppliers_SuppliersId",
                table: "CarsSuppliers",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_parts_CarsId",
                table: "parts",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_parts_CategoryId",
                table: "parts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_parts_SuppliersId",
                table: "parts",
                column: "SuppliersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsSuppliers");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}

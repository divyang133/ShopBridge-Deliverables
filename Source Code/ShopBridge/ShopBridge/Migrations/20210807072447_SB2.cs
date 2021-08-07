using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.Migrations
{
    public partial class SB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblProductDetails_ProductName",
                table: "tblProductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductDetails_ProductName_Brand",
                table: "tblProductDetails",
                columns: new[] { "ProductName", "Brand" },
                unique: true,
                filter: "[Brand] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblProductDetails_ProductName_Brand",
                table: "tblProductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductDetails_ProductName",
                table: "tblProductDetails",
                column: "ProductName",
                unique: true);
        }
    }
}

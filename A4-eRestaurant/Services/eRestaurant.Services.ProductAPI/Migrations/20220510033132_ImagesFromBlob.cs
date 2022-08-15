using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Services.ProductAPI.Migrations
{
    public partial class ImagesFromBlob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://stforeshop.blob.core.windows.net/a1-erestaurant/food-product-1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://stforeshop.blob.core.windows.net/a1-erestaurant/food-product-2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://stforeshop.blob.core.windows.net/a1-erestaurant/food-product-3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://stforeshop.blob.core.windows.net/a1-erestaurant/food-product-4.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://dotnetmastery.blob.core.windows.net/mango/14.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://dotnetmastery.blob.core.windows.net/mango/12.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://dotnetmastery.blob.core.windows.net/mango/11.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://dotnetmastery.blob.core.windows.net/mango/13.jpg");
        }
    }
}

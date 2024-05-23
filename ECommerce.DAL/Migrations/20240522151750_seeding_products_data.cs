using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_products_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Category", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Category 1", "Description for Product 1", "https://example.com/product1.jpg", "Product 1", 9.99m },
                    { 2, "Category 2", "Description for Product 2", "https://example.com/product2.jpg", "Product 2", 19.99m },
                    { 3, "Category 3", "Description for Product 3", "https://example.com/product3.jpg", "Product 3", 29.99m },
                    { 4, "Category 1", "Description for Product 4", "https://example.com/product4.jpg", "Product 4", 14.99m },
                    { 5, "Category 2", "Description for Product 5", "https://example.com/product5.jpg", "Product 5", 24.99m },
                    { 6, "Category 3", "Description for Product 6", "https://example.com/product6.jpg", "Product 6", 34.99m },
                    { 7, "Category 1", "Description for Product 7", "https://example.com/product7.jpg", "Product 7", 11.99m },
                    { 8, "Category 2", "Description for Product 8", "https://example.com/product8.jpg", "Product 8", 21.99m },
                    { 9, "Category 3", "Description for Product 9", "https://example.com/product9.jpg", "Product 9", 31.99m },
                    { 10, "Category 1", "Description for Product 10", "https://example.com/product10.jpg", "Product 10", 15.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

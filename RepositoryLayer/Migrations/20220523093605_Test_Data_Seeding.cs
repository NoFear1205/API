using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class Test_Data_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Loại 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Loại 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Loại 3" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Image", "Name", "Provider" },
                values: new object[] { 1, 1, "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg", "Mặt hàng 1", "Nhà cung cấp 1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Image", "Name", "Provider" },
                values: new object[] { 2, 3, "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg", "Mặt hàng 2", "Nhà cung cấp 1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Image", "Name", "Provider" },
                values: new object[] { 3, 2, "/images/2205230920350406e644b7233cfcc96c4bcbd73f2f2f.jpg", "Mặt hàng 3", "Nhà cung cấp 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);
        }
    }
}

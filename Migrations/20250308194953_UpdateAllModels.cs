using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UserId" },
                values: new object[] { 1, new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7218), "Latest model IPhone", "IPhone 14", 900, 3, 2 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UserId" },
                values: new object[] { 3, 1, new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7219), "Noise-canceling with long battery life", "Wireless Headphones", 250, 8, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7234));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 1, 17, 35, 48, 152, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 17, 35, 48, 152, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UserId" },
                values: new object[] { 2, new DateTime(2025, 3, 1, 17, 35, 48, 152, DateTimeKind.Utc).AddTicks(4871), "Learn C#", "C# Programming", 45, 50, 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 17, 35, 48, 152, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 17, 35, 48, 152, DateTimeKind.Utc).AddTicks(4891));
        }
    }
}

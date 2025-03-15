using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4071));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UserId" },
                values: new object[] { 4, 1, new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4072), "Noise-canceling with long battery life", "Wired Headphones", 250, 8, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4087));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9454));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UserId" },
                values: new object[] { 3, 1, new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9455), "Noise-canceling with long battery life", "Wired Headphones", 250, 8, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9472));
        }
    }
}

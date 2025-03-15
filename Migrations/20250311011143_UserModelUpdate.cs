using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class UserModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "isSeller",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "StockQuantity", "UserId" },
                values: new object[] { 3, 1, new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4341), "Noise-canceling with long battery life", "Wired Headphones", 250, 8, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4357));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<bool>(
                name: "isSeller",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedAt", "isSeller" },
                values: new object[] { new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4086), true });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "isSeller" },
                values: new object[] { new DateTime(2025, 3, 11, 0, 18, 5, 948, DateTimeKind.Utc).AddTicks(4087), false });
        }
    }
}

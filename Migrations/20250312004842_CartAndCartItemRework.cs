using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class CartAndCartItemRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_PaymentType_PaymentTypeId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_PaymentTypeId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PriceAtPurchase",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceAtSale",
                table: "CartItem",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Cart",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Cart",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Cart",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletionDate", "PaymentType", "TotalCost" },
                values: new object[] { null, null, 0m });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Id", "CompletionDate", "PaymentType", "TotalCost", "UserId" },
                values: new object[] { 2, new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2529), "Credit Card", 45.99m, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PriceAtSale", "Shipped" },
                values: new object[] { 1200m, false });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceAtSale", "Shipped" },
                values: new object[] { 45m, false });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CartId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2661) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CartId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2662) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CartId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2663) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2681));

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "CartId", "PriceAtSale", "ProductId", "Shipped" },
                values: new object[] { 3, 2, 30m, 3, true });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartId",
                table: "Product",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CartId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PriceAtSale",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "PriceAtPurchase",
                table: "CartItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Cart",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Cart",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Completed", "OrderDate", "PaymentTypeId", "TotalPrice" },
                values: new object[] { false, new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4278), 1, 0 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PriceAtPurchase", "Quantity" },
                values: new object[] { 1200, 1 });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceAtPurchase", "Quantity" },
                values: new object[] { 45, 2 });

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

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 11, 1, 11, 43, 522, DateTimeKind.Utc).AddTicks(4341));

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

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PaymentTypeId",
                table: "Cart",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_PaymentType_PaymentTypeId",
                table: "Cart",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

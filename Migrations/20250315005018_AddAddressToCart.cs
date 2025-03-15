using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cart",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "PaymentId" },
                values: new object[] { "123 Main St", 1 });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CompletionDate", "PaymentId" },
                values: new object[] { "987 South St", null, 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 0, 50, 18, 541, DateTimeKind.Utc).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 0, 50, 18, 541, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 0, 50, 18, 541, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 0, 50, 18, 541, DateTimeKind.Utc).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 0, 50, 18, 541, DateTimeKind.Utc).AddTicks(3661));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Cart",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletionDate", "PaymentType" },
                values: new object[] { new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2529), "Credit Card" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 0, 48, 41, 894, DateTimeKind.Utc).AddTicks(2663));

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
        }
    }
}

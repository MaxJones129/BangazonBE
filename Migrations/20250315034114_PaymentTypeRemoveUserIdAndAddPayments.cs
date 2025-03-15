using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class PaymentTypeRemoveUserIdAndAddPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_User_UserId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_UserId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaymentType");

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "Id", "PaymentName" },
                values: new object[,]
                {
                    { 2, "MasterCard" },
                    { 3, "Discover" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 41, 14, 349, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 41, 14, 349, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 41, 14, 349, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 41, 14, 349, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 41, 14, 349, DateTimeKind.Utc).AddTicks(5425));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PaymentType",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 31, 59, 712, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 31, 59, 712, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 31, 59, 712, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 31, 59, 712, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 15, 3, 31, 59, 712, DateTimeKind.Utc).AddTicks(8161));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_UserId",
                table: "PaymentType",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_User_UserId",
                table: "PaymentType",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

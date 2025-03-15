using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class MakeEmailUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Uid");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9455), "Wired Headphones" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt", "Email", "Uid" },
                values: new object[] { "987 South St", new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9470), "emailexample456@email.com", "RplI9hf723kvcZZs" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedAt", "Email", "Uid" },
                values: new object[] { "123 Main St", new DateTime(2025, 3, 11, 0, 5, 28, 362, DateTimeKind.Utc).AddTicks(9472), "emailexample123@email.com", "76FJhdpekly73k7K" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Uid",
                table: "User",
                newName: "Password");

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
                column: "CreatedAt",
                value: new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7219), "Wireless Headphones" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7234), "hashedpassword1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 3, 8, 19, 49, 53, 622, DateTimeKind.Utc).AddTicks(7234), "hashedpassword2" });
        }
    }
}

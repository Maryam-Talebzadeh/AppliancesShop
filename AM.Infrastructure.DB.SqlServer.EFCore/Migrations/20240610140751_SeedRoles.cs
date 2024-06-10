using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 10, 7, 7, 42, 996, DateTimeKind.Local).AddTicks(5758), false, "مدیرسیستم" },
                    { 2L, new DateTime(2024, 6, 10, 7, 7, 42, 996, DateTimeKind.Local).AddTicks(5965), false, "کاربر عادی" },
                    { 3L, new DateTime(2024, 6, 10, 7, 7, 42, 996, DateTimeKind.Local).AddTicks(5988), false, "محتوا گذار" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}

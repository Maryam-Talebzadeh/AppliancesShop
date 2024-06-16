using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddColleagueUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 16, 9, 22, 20, 791, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(816));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Name" },
                values: new object[] { 4L, new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(864), false, "کاربر همکار" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 6, 38, 15, 751, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 6, 38, 15, 752, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 6, 38, 15, 752, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 6, 38, 15, 752, DateTimeKind.Local).AddTicks(2894));
        }
    }
}

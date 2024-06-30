using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColleagueDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColleagueDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDiscounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomerDiscounts",
                columns: new[] { "Id", "CreationDate", "DiscountRate", "EndDate", "IsRemoved", "ProductId", "Reason", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(721), 40, new DateTime(2024, 7, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(668), false, 4L, "جشنواره", new DateTime(2024, 6, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(482) },
                    { 2L, new DateTime(2024, 6, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(940), 25, new DateTime(2024, 7, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(919), false, 3L, "جشنواره", new DateTime(2024, 6, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(904) },
                    { 3L, new DateTime(2024, 6, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(1008), 10, new DateTime(2024, 7, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(992), false, 1L, "جشنواره", new DateTime(2024, 6, 29, 7, 53, 33, 302, DateTimeKind.Local).AddTicks(979) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColleagueDiscounts");

            migrationBuilder.DropTable(
                name: "CustomerDiscounts");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 29, 7, 26, 13, 593, DateTimeKind.Local).AddTicks(9517), false, "مدیرسیستم" },
                    { 2L, new DateTime(2024, 6, 29, 7, 26, 13, 593, DateTimeKind.Local).AddTicks(9645), false, "کاربر عادی" },
                    { 3L, new DateTime(2024, 6, 29, 7, 26, 13, 593, DateTimeKind.Local).AddTicks(9664), false, "محتوا گذار" },
                    { 4L, new DateTime(2024, 6, 29, 7, 26, 13, 593, DateTimeKind.Local).AddTicks(9679), false, "کاربر همکار" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreationDate", "Fullname", "IsRemoved", "Mobile", "Password", "ProfilePhoto", "RoleId", "Username" },
                values: new object[] { 1L, new DateTime(2024, 6, 29, 7, 26, 13, 593, DateTimeKind.Local).AddTicks(2672), "Mary", false, "09386485663", "10000.lyz67IGPgBUonnD4LNGVTQ==.4tH6b2mcWg+vVPSEHhzaEX0aatIlFdqGDcI+NUA/VLA=", "DefaultAvatar.jpg", 1L, "Mary" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Code", "RoleId" },
                values: new object[,]
                {
                    { 1L, 52, 1L },
                    { 2L, 53, 1L },
                    { 3L, 54, 1L },
                    { 4L, 55, 1L },
                    { 6L, 56, 1L },
                    { 7L, 51, 1L },
                    { 8L, 12, 1L },
                    { 9L, 13, 1L },
                    { 10L, 10, 1L },
                    { 11L, 11, 1L },
                    { 12L, 22, 1L },
                    { 13L, 23, 1L },
                    { 14L, 20, 1L },
                    { 15L, 21, 1L },
                    { 18L, 50, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

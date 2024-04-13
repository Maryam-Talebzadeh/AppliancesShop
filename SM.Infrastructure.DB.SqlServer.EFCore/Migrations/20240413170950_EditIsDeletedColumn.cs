using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class EditIsDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Slides");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "SlidePictures",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductPictures",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductCategories",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Pictures",
                newName: "IsRemoved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "SlidePictures",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "ProductPictures",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "ProductCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Pictures",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Slides",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    PayAmount = table.Column<double>(type: "float", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IssueTrackingNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlidePictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlidePictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    KeyWords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BtnText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slides_SlidePictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "SlidePictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Inventory = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "Alt", "CreationDate", "IsRemoved", "Name", "Title" },
                values: new object[,]
                {
                    { 1L, "دکوری", new DateTime(2024, 6, 29, 11, 17, 13, 365, DateTimeKind.Local).AddTicks(235), false, "cf827bdd90884e36aee3fecd26617036.jpg", "دکوری" },
                    { 2L, "راحتی", new DateTime(2024, 6, 29, 11, 17, 13, 365, DateTimeKind.Local).AddTicks(366), false, "6ca4f38a6635446db326f54283659b2e.jpg", "راحتی" },
                    { 3L, "گلدان", new DateTime(2024, 6, 29, 11, 17, 13, 365, DateTimeKind.Local).AddTicks(432), false, "e6f462ad8ec14614accc243ebf42558e.jpg", "گلدان" }
                });

            migrationBuilder.InsertData(
                table: "SlidePictures",
                columns: new[] { "Id", "Alt", "CreationDate", "IsRemoved", "Name", "Title" },
                values: new object[,]
                {
                    { 1L, "مبل", new DateTime(2024, 6, 29, 11, 17, 13, 368, DateTimeKind.Local).AddTicks(512), false, "5099b0fa6ac04deca0452dd70bedb89a.jpg", "مبل" },
                    { 2L, "ساعت", new DateTime(2024, 6, 29, 11, 17, 13, 368, DateTimeKind.Local).AddTicks(647), false, "6aef82656ec6439388b7d50739a65f87.jpg", "ساعت" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreationDate", "Description", "IsRemoved", "KeyWords", "MetaDescription", "Name", "PictureId", "Slug" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 6, 29, 11, 17, 13, 366, DateTimeKind.Local).AddTicks(3426), "انواع لوازم دکوری خانه", false, "لوازم دکوری", "انواع لوازم دکوری خانه", "دکوری", 1L, "دکوری" },
                    { 2L, new DateTime(2024, 6, 29, 11, 17, 13, 366, DateTimeKind.Local).AddTicks(3477), "انواع لوازم راحتی خانه", false, "لوازم راحتی", "انواع لوازم راحتی خانه", "راحتی", 2L, "راحتی" },
                    { 3L, new DateTime(2024, 6, 29, 11, 17, 13, 366, DateTimeKind.Local).AddTicks(3489), "انواع گلدان های سرامیکی و سفالی", false, "گلدان", "انواع گلدان های سرامیکی و سفالی", "گلدان", 3L, "گلدان" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "BtnText", "CreationDate", "Heading", "IsRemoved", "Link", "PictureId", "Text", "Title" },
                values: new object[,]
                {
                    { 1L, "#Products", new DateTime(2024, 6, 29, 11, 17, 13, 367, DateTimeKind.Local).AddTicks(3514), "دنبال قشنگ کردن خونتی؟", false, "اینجا کلیک کن", 1L, "تا جمعه وقت داری با 40 درصد تخفیف خونتو قشنگ تر کنی", "ما با 40 درصد تخفیف کمکت میکنیم" },
                    { 2L, "#Products", new DateTime(2024, 6, 29, 11, 17, 13, 367, DateTimeKind.Local).AddTicks(3645), "میخوای کادو بخری؟", false, "کلیک کن", 2L, "ما واسه یه سری لوازم دکوری تخفیف 30 درصد زدیم. از دستش نده", "با 30 درصد تخفیف کادو بخر" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "CreationDate", "Description", "Inventory", "IsRemoved", "Keywords", "MetaDescription", "Name", "ShortDescription", "Slug" },
                values: new object[,]
                {
                    { 1L, 3L, "1", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5178), "گلدان بلند سفید سرامیکی مخصوص گل های آپارتمانی", true, false, "گلدان سرامیکی سفید", "گلدان بلند سفید سرامیکی مخصوص گل های آپارتمانی", "گلدان سرامیکی سفید", "گلدان بلند سفید سرامیکی مخصوص گل های آپارتمانی", "گلدان-سرامیکی-سفید" },
                    { 2L, 2L, "2", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5236), "صندلی راحتی پایه کوتاه از جنس لنین", true, false, "صندلی راحتی پایه کوتاه", "صندلی راحتی پایه کوتاه از جنس لنین", "صندلی راحتی", "صندلی راحتی پایه کوتاه از جنس لنین", "صندلی-راحتی" },
                    { 3L, 2L, "3", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5255), "صندلی پاف بدون پایه استوانه ای طرح سنتی، داخل پشم شیشه.", true, false, "صندلی پاف بدون پایه", "صندلی پاف بدون پایه استوانه ای طرح سنتی ", "صندلی پاف بدون پایه", "صندلی پاف بدون پایه استوانه ای طرح سنتی ", "صندلی-پاف-بدون-پایه" },
                    { 4L, 1L, "4", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5273), "چراغ پایه بلند با قابلیت کوتاه بلند کردن تا سقف 200 سانتی متر", true, false, "چراغ پایه بلند", "چراغ پایه بلند با قابلیت کوتاه بلند کردن تا سقف 200 سانتی متر ", "چراغ پایه بلند", "چراغ پایه بلند با قابلیت کوتاه بلند کردن تا سقف 200 سانتی متر ", "چراغ-پایه-بلند" },
                    { 5L, 2L, "5", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5290), "اوراگانایزر استوانه ای پارچه ای مخصوص لباس مدل HiMode\r\nمشخصات فنی : 27x27x27  سانتی متر\r\nجنس : نمد", true, false, "اورگانایزر پارچه ای", "اوراگانایزر استوانه ای پارچه ای مخصوص لباس ", "اورگانایزر پارچه ای", "اوراگانایزر استوانه ای پارچه ای مخصوص لباس", "اورگانایزر-پارچه-ای" },
                    { 6L, 1L, "6", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5426), "چراغ سطلی پایه کوتاه با ارتفاع 50 سانتی متر و لایتینک زرد، سفید و بنفشجنس : نمد", true, false, "چراغ سطلی", "چراغ سطلی پایه کوتاه ", "چراغ سطلی", "چراغ سطلی", "چراغ-سطلی" },
                    { 7L, 3L, "7", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5444), "گلدان پایه دار با پایه برنجی و جنس سرامیکی با ارتفاع 200 سانتی متر", true, false, "گلدان پایه دار", "گلدان پایه دار با پایه برنجی و جنس سرامیکی ", "گلدان پایه دار", "گلدان پایه دار با پایه برنجی و جنس سرامیکی", "گلدان-پایه-دار" },
                    { 8L, 3L, "8", new DateTime(2024, 6, 29, 11, 17, 13, 363, DateTimeKind.Local).AddTicks(5462), "استند گل چوبی با ارتفاع متغیر تا سقف 400 سانتی متر", true, false, "استند گل چوبی", "استند گل چوبی", "استند گل", "استند گل چوبی ", "استند-گل" }
                });

            migrationBuilder.InsertData(
                table: "ProductPictures",
                columns: new[] { "Id", "CreationDate", "IsRemoved", "Picture", "PictureAlt", "PictureTitle", "ProductId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "4dcea8c370e84a4583dd11c36918db46.jpg", "گلدان سرامیکی سفید", "گلدان سرامیکی سفید", 1L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "9409d0dde40c464eb10e81cdb7e819d9.jpg", "گلدان سرامیکی سفید", "گلدان سرامیکی سفید", 1L },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "47157c1ce82f4a9f9f325139056044bf.jpg", "صندلی  راحتی", "صندلی راحتی", 2L },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "8637033e7a324e4ea1f6aaf0a6809b83.jpg", "صندلی  راحتی", "صندلی راحتی", 2L },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "667bd11e85894f72ba29c3c1cdf6fb45.jpg", "صندلی پاف بدون پایه", "صندلی پاف بدون پایه", 3L },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "d7bce363d9cf413ca85582dab5019577.jpg", "چراغ پایه بلند", "چراغ پایه بلند", 4L },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "a1f312cb804247aa83042f508efd9b2e.jpg", "اورگانایزر پارچه ای", "اورگانایزر پارچه ای", 5L },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "1611d83ade5946bdb99dc033d8cd5940.jpg", "چراغ سطلی", "چراغ سطلی", 6L },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "e7e81158e93d4ffaa146e5f9bc6cbdce.jpg", "چراغ سطلی", "چراغ سطلی", 6L },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "5ad0368c3d1a4684abd4bd8bb72e3700.jpg", "گلدان پایه دار", "گلدان پایه دار", 7L },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "af08b9d21c2f4d2bb582a8d67865129e.jpg", "گلدان پایه دار", "گلدان پایه دار", 7L },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "7408008595fc46879ab174b54e5f5141.jpg", "استند گل", "استند گل", 8L },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "42f851066cbc457f964c3ef01545ce1d.jpg", "استند گل", "استند گل", 8L },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "d73fe5a82d26447f8022d0cfd6448e95.jpg", "صندلی پاف بدون پایه", "صندلی پاف بدون پایه", 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_PictureId",
                table: "ProductCategories",
                column: "PictureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPictures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_PictureId",
                table: "Slides",
                column: "PictureId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SlidePictures");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}

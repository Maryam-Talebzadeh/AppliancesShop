﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ShowOrder = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "CanonicalAddress", "CreationDate", "Description", "IsRemoved", "Keywords", "MetaDescription", "Name", "Picture", "PictureAlt", "PictureTitle", "ShowOrder", "Slug" },
                values: new object[] { 1L, "", new DateTime(2024, 6, 29, 7, 46, 14, 726, DateTimeKind.Local).AddTicks(7952), "مقالات درباره لوازم خانگی", false, "لوازم خانگی", "مقالات درباره لوازم خانگی", "لوازم خانگی", "2024-06-27-16-02-13-Sage-Green-Electrics-Collection-1200x675.jpg", "لوازم خانگی", "لوازم خانگی", 1, "لوازم-خانگی" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CanonicalAddress", "CategoryId", "CreationDate", "Description", "IsRemoved", "Keywords", "MetaDescription", "Picture", "PictureAlt", "PictureTitle", "PublishDate", "ShortDescription", "Slug", "Title" },
                values: new object[,]
                {
                    { 1L, "", 1L, new DateTime(2024, 6, 29, 7, 46, 14, 727, DateTimeKind.Local).AddTicks(5540), "<ul style=\"list-style-type: disc;\">\r\n<li>\r\n<article id=\"post-15177\">\r\n<h3>وسایل خانگی بزرگ</h3>\r\n<p>لوازم خانگی بزرگ که اغلب معروف به کالاهای سفید هستند، شامل یخچال و فریزر، ماشین ظرف&zwnj;شویی، ماشین لباسشویی، سیستم تهویه، اجاق&zwnj;گاز، آب&zwnj;گرم&zwnj;کن و&hellip; می&zwnj;شوند. لوازم خانگی بزرگ معمولاً بسیار اهمیت دارند و وجودشان در خانه ضروری است.</p>\r\n<p>به&zwnj;عنوان&zwnj;مثال بدون یخچال در خانه نمی&zwnj;توان زندگی کرد؛ زیرا مواد غذایی در دمای بیرون فاسد می&zwnj;شوند. برای پختن غذا وجود اجاق&zwnj;گاز و یا ماکروویو ضروری است و بدون آن&zwnj;ها نمی&zwnj;توان غذا پخت. همچنین با توجه به اینکه این لوازم کاربرد بسیاری دارند باید در خرید آنها دقت بیشتری داشته باشید.</p>\r\n<h3>لوازم خانگی کوچک</h3>\r\n<p>در تحقیق در مورد لوازم خانگی می&zwnj;توان لوازم خانگی را به دو گروه بزرگ و کوچک تقسیم کرد، برای تحقیق لوازم خانگی کوچک ابتدا باید آن&zwnj;ها را بشناسیم. لوازم خانگی کوچک شامل ماشین&zwnj;های الکتریکی کوچکی در خانه هستند که کاربرد بسیاری دارند و حمل آن&zwnj;ها آسان است. از لوازم خانگی کوچک می&zwnj;توان آبمیوه&zwnj;گیر، همزن برقی، چرخ گوشت، قهوه&zwnj;ساز، چای&zwnj;ساز، سرخ&zwnj;کن برقی، آسیاب کن، مخلوط&zwnj;کن برقی، خردکن و غذاساز، کتری برقی، ساندویچ&zwnj;ساز و پلوپز را نام برد.</p>\r\n<div id=\"attachment_15182\"><br>\r\n<p id=\"caption-attachment-15182\">لوازم خانگی کوچک شامل ماشین&zwnj;های الکتریکی کوچک هستند و حمل آن&zwnj;ها آسان است.</p>\r\n</div>\r\n<h3>لیست لوازم خانگی ضروری</h3>\r\n<p>شما باید برای شروع زندگی مستقل و یا زندگی مشترک جدید برخی از لوازم خانگی ضروری را تهیه کنید. در حقیقت بخش بزرگی از زندگی به وجود این لوازم بستگی دارند، از جمله این موارد می&zwnj;توان آشپزی، استراحت و حتی مطالعه را نام برد.</p>\r\n<p>ما در تحقیق در مورد صنعت لوازم خانگی به بررسی کامل لوازم موردنیاز در بخش&zwnj;های مختلف زندگی می&zwnj;پردازیم. با توجه به اینکه این لوازم اهمیت بالایی در کیفیت زندگی دارند تحقیق لوازم خانگی ضروری است تا بتوانید لوازم خانگی مرغوب و لازم را بخرید. در ادامه لیست بخش&zwnj;های مختلف که لوازم خانگی خاص خود را نیاز دارند ملاحظه می&zwnj;کنید:</p>\r\n<ul style=\"list-style-type: disc;\">\r\n<li>مخصوص پخت&zwnj;وپز</li>\r\n<li>پذیرایی</li>\r\n<li>برای اتاق&zwnj;خواب</li>\r\n<li>برای اتاق کار</li>\r\n</ul>\r\n<h4>لوازم خانگی برقی</h4>\r\n<p>در تحقیق در مورد لوازم خانگی به این نتیجه می&zwnj;رسیم که انتخاب و تهیه لوازم خانگی برقی از اهمیت ویژه&zwnj;ای برخوردار است؛ زیرا این لوازم باید مرغوب باشند تا عمر مفید طولانی&zwnj;تری از خود نشان دهند. بسیاری از لوازم بخش&zwnj;های مختلف با استفاده از برق کار می&zwnj;کنند و نکته قابل&zwnj;توجه این است که داشتن محافظ برای لوازم برقی بزرگ کاملاً ضروری است. با قطعی برق و یا تغیر ولتاژ ناگهانی ممکن است وسیله برقی شما بسوزند. در ادامه لیست اسامی برخی از لوازم خانگی برقی را مشاهده می&zwnj;کنید:</p>\r\n<ul style=\"list-style-type: disc;\">\r\n<li>یخچال فریزر</li>\r\n<li>مایکروویو</li>\r\n<li>ماشین ظرف&zwnj;شویی</li>\r\n<li>ماشین لباسشویی</li>\r\n<li>همزن برقی</li>\r\n</ul>\r\n<div id=\"attachment_15183\"><br>\r\n<p id=\"caption-attachment-15183\">لوازم خانگی باید مرغوب باشند تا عمر مفید طولانی&zwnj;تری داشته باشند.</p>\r\n</div>\r\n<h4>لوازم خانگی موردنیاز در اتاق کار</h4>\r\n<p>یکی از مهم&zwnj;ترین قسمت&zwnj;های خانه اتاق کار است که باید لوازم موردنیاز برای کار شما را داشته باشد. در تحقیق در مورد لوازم خانگی ما به بررسی لوازم موردنیاز در اتاق کار نیز می&zwnj;پردازیم. برخی از لوازم موردنیاز در اتاق کار برقی هستند؛ از جمله چراغ مطالعه، لپ&zwnj;تاپ، شارژر، سه&zwnj;راهی. بعضی دیگر از لوازم خانگی لازم در اتاق کار بدون استفاده از برق کارایی خود را دارند مثل میز کار و کتابخانه.</p>\r\n<p>در تهیه لوازم اتاق کارتان نهایت دقت را به کار ببرید؛ زیرا با کیفیت کار شما ارتباط مستقیم دارد. به&zwnj;عنوان&zwnj;مثال لپ&zwnj;تاپی که انتخاب می&zwnj;کنید باید ظرفیت&zwnj;های متناسب با کار شما را داشته باشد. برای کارهای معمولی با لپ&zwnj;تاپ&zwnj;های ارزان&zwnj;قیمت نیز می&zwnj;توان سر کرد اما کارهای تخصصی نیازمند صرف هزینه بیشتری هستند.</p>\r\n<h4>لوازم خانگی پذیرایی</h4>\r\n<p>با توجه به اینکه حضور میهمان اغلب در قسمت پذیرایی است، باید در تهیه لوازم آن نهایت سلیقه را به کار برد تا یک منزل با اتاق پذیرایی بسیار زیبا داشته باشید. در موضوع تحقیق در مورد لوازم خانگی، لیست لوازم خانگی مربوط به اتاق پذیرایی تنوع زیادی دارد. اغلب لوازم مربوط به این قسمت از خانه به دکوراسیون کلی منزل شما بستگی بسیاری دارد. معمولاً در خانه&zwnj;های ایرانی بخش زیادی از لوازم خانگی پذیرایی شامل لوازم چوبی هستند. در ادامه لیست لوازم خانگی اتاق پذیرایی را مشاهده می&zwnj;کنید:</p>\r\n<ol style=\"list-style-type: decimal;\">\r\n<li>ضبط صوت</li>\r\n<li>تلویزیون</li>\r\n<li>فرش</li>\r\n<li>بوفه</li>\r\n<li>میز تلویزیون</li>\r\n<li>میز ناهارخوری</li>\r\n<li>ست مبلمان</li>\r\n<li>کوسن مبل تزئینی</li>\r\n<li>روانداز مبل</li>\r\n<li>ساعت دیواری</li>\r\n<li>لوستر پذیرایی</li>\r\n<li>آباژور</li>\r\n<li>تلفن</li>\r\n</ol>\r\n<h4>لوازم خانگی موردنیاز برای پخت&zwnj;وپز</h4>\r\n<p>می&zwnj;توان گفت قلب هر خانه&zwnj;ای&nbsp;<a href=\"https://barayekharid.com/%d8%a8%d8%b1%d8%a7%db%8c-%d9%85%d8%ad%d9%84-%da%a9%d8%a7%d8%b1-%d8%a7%db%8c%d9%86-%d9%84%d9%88%d8%a7%d8%b2%d9%85-%d8%a2%d8%b4%d9%be%d8%b2%d8%ae%d8%a7%d9%86%d9%87-%d8%b6%d8%b1%d9%88%d8%b1%db%8c-%d8%a7/\"><strong>آشپزخانه</strong></a>&nbsp;است؛ زیرا ضروری&zwnj;ترین امور زندگی در آن صورت می&zwnj;گیرد. لوازم بسیاری برای آشپزی و صرف غذا وجود دارند که همگی در آشپزخانه جای دارند. اگر آشپزخانه شما تکمیل باشد تقریباً واجبات اولیه زندگی فراهم خواهد بود.</p>\r\n<p>پس حتی اگر جوان مستقلی هستید که به تازگی در خانه&zwnj;ای جدید سکونت دارید باید ابتدا لوازم خانگی مربوط به آشپزخانه را تهیه کنید. اغلب لوازم آشپزخانه مربوط به پخت&zwnj;وپز هستند؛ در ادامه لیست لوازم برقی و غیر برقی مربوط به پخت&zwnj;وپز را ملاحظه می&zwnj;کنید:</p>\r\n<p>لوازم خانگی برقی موردنیاز برای پخت&zwnj;وپز</p>\r\n<ol style=\"list-style-type: decimal;\">\r\n<li>پلوپز</li>\r\n<li>سرخ&zwnj;کن</li>\r\n<li>آرام&zwnj;پز</li>\r\n<li>زودپز</li>\r\n<li>بخارپز</li>\r\n<li>اجاق&zwnj;گاز</li>\r\n<li>غذاساز</li>\r\n<li>چای&zwnj;ساز</li>\r\n<li>قهوه&zwnj;ساز</li>\r\n<li>توستر</li>\r\n<li>ماکروویو</li>\r\n<li>ساندویچ&zwnj;ساز</li>\r\n</ol>\r\n<div id=\"attachment_15184\"><br>\r\n<p id=\"caption-attachment-15184\">می&zwnj;توان گفت قلب هر خانه&zwnj;ای&nbsp;<a href=\"https://barayekharid.com/guide-to-buying-kitchen-appliances/\"><strong>آشپزخانه</strong></a>&nbsp;است.</p>\r\n</div>\r\n<h4>لیست لوازم غیر برقی موردنیاز برای پخت&zwnj;وپز</h4>\r\n<ol style=\"list-style-type: decimal;\">\r\n<li>سرویس قاشق</li>\r\n<li>قهوه&zwnj;خوری</li>\r\n<li>سرویس ظروف مهمان</li>\r\n<li>فلاسک چای</li>\r\n<li>سرویس ظروف دم&zwnj;دستی</li>\r\n<li>کفگیر و ملاقه</li>\r\n<li>سرویس چینی</li>\r\n<li>قوری و کتری</li>\r\n<li>سرویس قابلمه تفلون</li>\r\n<li>انواع سینی</li>\r\n<li>سرویس پلاستیک</li>\r\n<li>شیشه&zwnj;های مخصوص یخچال و کابینت</li>\r\n<li>سرویس دم&zwnj;کنی</li>\r\n<li>نمکدان و فلفل&zwnj;دان</li>\r\n<li>سرویس چاقو</li>\r\n<li>ظرف روغن مایع</li>\r\n<li>نسکافه خوری</li>\r\n<li>شیشه آب</li>\r\n<li>ست استکان</li>\r\n<li>پارچ و لیوان</li>\r\n<li>کارد میوه&zwnj;خوری</li>\r\n<li>سیخ</li>\r\n<li>توری ماهی و کباب</li>\r\n<li>جای نان</li>\r\n<li>در باز کن</li>\r\n<li>کفگیر و چنگال چوبی</li>\r\n<li>گوشت&zwnj;کوب</li>\r\n<li>چاقوی کیک</li>\r\n<li>اسفند دود کن</li>\r\n<li>چای&zwnj;صاف&zwnj;کن</li>\r\n<li>رنده معمولی</li>\r\n<li>تخته گوشت چوبی</li>\r\n<li>جای سیب&zwnj;زمینی و پیاز</li>\r\n<li>ترازوی آشپزخانه</li>\r\n</ol>\r\n<h4>نقش پلوپز در آشپزخانه</h4>\r\n<p>می&zwnj;توان گفت برای پختن برنج به صورت کته، بهترین انتخاب پلوپز است. وجود پلوپز در آشپزخانه شما امری ضروری به حساب می&zwnj;آید. گل سر سبد سفره&zwnj;های ایرانی ته&zwnj;دیگ خوشمزه است که با پختن برنج در پلوپز ته&zwnj;دیگ بسیار زیبا و خوشمزه&zwnj;ای برای سفره&zwnj;های رنگی شما فراهم می&zwnj;شود. اغلب این&zwnj;گونه جا افتاده است که پلوپزها صرفاً برای پخت برنج باشند.</p>\r\n<p>در صورتی که علاوه بر برنج می&zwnj;توانید مرغ، ماهی، سبزیجات و حتی کیک نیز بپزید. نکته&zwnj;ای که در هنگام خرید باید به آن توجه داشته باشید ظرفیت دستگاه پلوپزی هست که خریداری می&zwnj;کنید. ظرفیت پلوپز باید مناسب تعداد افراد خانواده باشد. همچنین به جنس بدنه نیز توجه داشته باشید که موقع پخت نباید گرما به بیرون منتقل شود.</p>\r\n<h4>ضرورت خرید اجاق&zwnj;گاز</h4>\r\n<p>برای آشپزی در منزل ضروری&zwnj;ترین لوازم خانگی، اجاق&zwnj;گاز است که نمی&zwnj;توان آن را به هیچ وجه نادیده گرفت. هنگام تحقیق در مورد لوازم خانگی توجه داشته باشید برای خرید اجاق&zwnj;گاز به سراغ برندهای با کیفیت بروید؛ زیرا این وسیله در منزل شما کاربرد روزانه دارد و در هر وعده باید غذای خود را روی آن بپزید.</p>\r\n<p>یکی از نکات مهمی که باید در خرید اجاق&zwnj;گاز به آن توجه کنید این است که شما اجاق&zwnj;گاز معمولی می&zwnj;خواهید یا قصد دارید اجاق شما مجهز به فر نیز باشد. بعد از گرفتن تصمیم در این مورد انتخاب&zwnj;های متنوعی برای شما وجود دارند. حتی اگر جای کافی ندارید می&zwnj;توانید اجاق رومیزی تهیه کنید.</p>\r\n<div id=\"attachment_15185\"><br>\r\n<p id=\"caption-attachment-15185\">اگر جای کافی ندارید می&zwnj;توانید اجاق رومیزی تهیه کنید.</p>\r\n</div>\r\n<h4>کاربرد&nbsp;<a href=\"https://barayekharid.com/product-category/home-and-kitchen/kitchen/fryer/\" aria-invalid=\"true\"><strong>سرخ&zwnj;کن</strong></a></h4>\r\n<p>یکی از لوازم خانگی کاربردی در آشپزخانه سرخ&zwnj;کن است که امکان تهیه مواد غذایی خوشمزه را برای شما فراهم می&zwnj;کند. سرخ&zwnj;کن&zwnj;های جدید با پیشرفت تکنولوژی روغن کمی لازم دارند. سرخ&zwnj;کن برقی امکان پخت انواع مختلف مواد غذایی خوشمزه را به شما می&zwnj;دهد.</p>\r\n<p>حتماً موقع انتخاب سرخ&zwnj;کن به ظرفیت و تعداد خود دقت کنید تا موقع پخت اندازه مواد غذایی متناسب با اعضای خانواده باشد. نکته مهم دیگر در تحقیق در مورد لوازم خانگی سرخ&zwnj;کن این است که حتماً به فیلتر این دستگاه دقت کنید تا قابل تعویض باشد؛ زیرا بعد از مدتی بوی حاصل از سرخ کردن توسط فیلتر جذب شده و باید عوض شود.</p>\r\n<div id=\"attachment_15186\"><br>\r\n<p id=\"caption-attachment-15186\">موقع انتخاب سرخ&zwnj;کن به ظرفیت و تعداد خود دقت کنید.</p>\r\n</div>\r\n<h4>نحوه استفاده از&nbsp;<a href=\"https://barayekharid.com/product-category/home-and-kitchen/kitchen/toaster/\" aria-invalid=\"true\"><strong>توستر</strong></a></h4>\r\n<p>همان گونه که می&zwnj;دانید توستر برای برشته و ترد کردن نان به کار می&zwnj;رود، همچنین از توستر می&zwnj;توانید برای آب کردن پنیر و یا گرم کردن پیتزا استفاده کنید. یکی از لوازم خانگی که در آشپزخانه کاربرد زیادی دارد توستر است. با وجود توستر نان&zwnj;های فریز خود را داغ کنید و در مدت کوتاهی نان برشته برای صبحانه داشته باشید. مزیت مهم توستر سادگی در نحوه کار کردن با آن است. شما به راحتی و با دسترسی سریع می&zwnj;توانید از آن استفاده کنید.<img style=\"height: auto;\" src=\"https://barayekharid.com/wp-content/uploads/2022/02/8-5.jpg\" alt=\"فروشگاه اینترنتی برای خرید\" width=\"1378\" height=\"1378\" loading=\"lazy\" aria-describedby=\"caption-attachment-15187\"></p>\r\n<div id=\"attachment_15187\">\r\n<p id=\"caption-attachment-15187\">از توستر می&zwnj;توانید برای آب کردن پنیر و یا گرم کردن پیتزا نیز استفاده کنید.</p>\r\n</div>\r\n<h4>نحوه خرید&nbsp;<a href=\"https://barayekharid.com/product-category/home-and-kitchen/kitchen/electric-mixer/\"><strong>همزن</strong></a>&nbsp;برقی برای آشپزخانه</h4>\r\n<p>در هنگام تحقیق در مورد لوازم خانگی ممکن است در نگاه اول این&zwnj;طور به نظر برسد که چه نیازی به تهیه همزن برقی وجود دارد. اما با دانستن کاربرد آن متوجه می&zwnj;شوید که وجود آن در آشپزخانه ضرورت دارد. به صورت کلی دو نوع همزن وجود دارد که پایه&zwnj;دار و بدون پایه هستند. برای هم زدن بسیاری از مواد همزن برقی کاربرد ویژه&zwnj;ای دارد. هنگام هم زدن سفیده تخم&zwnj;مرغ و یا فرم دادن خامه کیک متوجه تفاوت همزن برقی و همزن دستی خواهید شد.</p>\r\n<h4>کاربرد ترازوی آشپزخانه</h4>\r\n<p>در این بخش از تحقیق در مورد لوازم خانگی به معرفی ترازوی آشپزخانه می&zwnj;پردازیم. شاید شما تا به حال از ترازوی آشپزخانه استفاده نکرده باشید و تصور کنید نیازی به آن ندارید اما با دانستن کاربرد آن متوجه می&zwnj;شوید چقدر وجود ترازوی آشپزخانه در منزل شما ضروری است.</p>\r\n<p>اگر قصد گرفتن رژیم دارید و می&zwnj;خواهید مقدار دقیق کالری دریافتی بدنتان را اندازه بگیرید و متناسب با نیاز بدنتان مقدار غذای لازم را تهیه کنید، ترازوی آشپزخانه بهترین انتخاب برای خرید است. همچنین برای پختن انواع مختلف کیک و شیرینی که حساسیت مقدار مواد در خوشمزگی نتیجه آشپزی شما تأثیر بسیاری دارد، می&zwnj;توانید از ترازوی آشپزخانه برای اندازه&zwnj;گیری استفاده کنید.</p>\r\n<div id=\"attachment_15188\"><br>\r\n<p id=\"caption-attachment-15188\">با دانستن کاربرد ترازو متوجه می&zwnj;شوید چقدر وجود آن در منزل شما ضروری است.</p>\r\n</div>\r\n<h4>استفاده از&nbsp;<a href=\"https://barayekharid.com/product-category/home-and-kitchen/kitchen/immersion-blender/\">مخلوط&zwnj;کن</a></h4>\r\n<p>مخلوط&zwnj;کن&zwnj;ها امروزه در آشپزخانه هر خانه&zwnj;ای کاربرد بسیاری دارند، از جمله کاربردهای مخلوط&zwnj;کن می&zwnj;توان به پوره کردن، آسیاب کردن، خرد کردن، مخلوط کردن و تکه&zwnj;تکه کردن سریع مواد غذایی مختلف اشاره کرد. مخلوط&zwnj;کن&zwnj;ها سرعت تهیه مواد غذایی را بالا می&zwnj;برند و باعث کاهش دشواری آشپزی می&zwnj;شوند.</p>\r\n<p>برای تحقیق در مورد لوازم خانگی باید ابتدا به میزان کارایی آن وسیله در خانه توجه کنید. هنگامی که کاربرد یک لوازم خانگی زیاد است تهیه آن به هیچ عنوان خالی از لطف نخواهد بود. در ادامه برخی از مواد تهیه شده توسط مخلوط&zwnj;کن را شرح دادیم:</p>\r\n<ul style=\"list-style-type: disc;\">\r\n<li>آب&zwnj;میوه و اسموتی مثل آب طالبی، آب هندوانه، شیر انبه، شیرموز، کیوی</li>\r\n<li>پوره مثل پوره کدوحلوایی، پوره موز، پوره گوجه&zwnj;فرنگی، پوره آناناس</li>\r\n<li>شیک و معجون مثل شیک کاراملی، شیک میوه و شیک قهوه</li>\r\n<li>انواع سس</li>\r\n<li>انواع پودر مثل پودر قند، پودر شکر و شکر قهوه&zwnj;ای برای قنادی و شیرینی&zwnj;پزی</li>\r\n<li>پودر ادویه از تکه&zwnj;های ادویه مانند چوب دارچین، گل سرخ و هل</li>\r\n<li>آسیاب قهوه تازه</li>\r\n<li>خرد کردن یخ</li>\r\n</ul>\r\n<div id=\"attachment_15189\"><br>\r\n<p id=\"caption-attachment-15189\">مخلوط&zwnj;کن&zwnj;ها سرعت تهیه مواد غذایی را بالا می&zwnj;برند.</p>\r\n</div>\r\n<h4>تفاوت ماکروفر و ماکروویو در لوازم خانگی</h4>\r\n<p>در تحقیق در مورد لوازم خانگی تفاوت بین ماکروفر و ماکروویو اهمیت دارد. فرق این دو لوازم خانگی به نحوه تولید گرما در پخت غذا ارتباط دارد که هر دو کاربرد مختلفی دارند و جایگاه متفاوتی را در بین لوازم خانگی مختلف به خود اختصاص داده&zwnj;اند. ماکروویو با تولید موج&zwnj;هایی با طول کوتاه باعث می&zwnj;شود غذا در زمان سریع&zwnj;تری نسبت به ماکروفر آماده شود.ماکروفر دارای المنت است و در زمان طولانی&zwnj;تر نسبت به ماکروویو غذا را به صورت مغز پخت آماده می&zwnj;کند.</p>\r\n<p>ماکروویو علاوه بر داغ کردن غذا و پختن غذا کاربردهای متنوع زیاد دیگری نیز دارد که تعدادی از آن&zwnj;ها به شرح زیر هستند:</p>\r\n<ul style=\"list-style-type: disc;\">\r\n<li>نرم کردن شکر قهوه&zwnj;ای</li>\r\n<li>نرم کردن عسل</li>\r\n<li>حرارت و استراحت دادن خمیر</li>\r\n<li>برشته کردن آجیل</li>\r\n</ul>\r\n<h4>استفاده ساندویچ&zwnj;ساز در آشپزخانه</h4>\r\n<p>ساندویچ&zwnj;ساز از لوازم خانگی کاربردی در آشپزخانه است که امکان پختن سریع یک وعده غذایی را برای شما فراهم می&zwnj;کند. این وسیله شاید برای بعضی افراد که سنتی هستند ضروری به نظر نرسد ولی امروزه با افزایش مشغله&zwnj;های زندگی و کمبود زمان، تهیه یک وعده غذایی سریع و لذیذ مزیت بزرگی برای شما است. اگر فرزند کوچکتان بد غذا است و اغلب به غذاهای رستورانی و فست&zwnj;فود تمایل دارد می&zwnj;توانید با ساندویچ&zwnj;ساز غذای سالم و محبوب فرزندتان را آماده کنید.</p>\r\n<h4>مزیت داشتن زودپز در آشپزخانه</h4>\r\n<p>در این بخش از مقاله تحقیق در مورد لوازم خانگی به معرفی زودپز می&zwnj;پردازیم. از انواع لوازم خانگی مربوط به پخت&zwnj;وپز که وجود آن در آشپزخانه لازم بوده زودپز برقی است. وضعیت&zwnj;های زیادی پیش می&zwnj;آیند که مجبور می&zwnj;شوید در مدت کوتاهی غذا بپزید.</p>\r\n<p>زودپز برقی با بالا بردن فشار و دما امکان پختن سریع مواد غذایی فراهم می&zwnj;کند. برای جا انداختن خورشتی که با گوشت یا مرغ طبخ می&zwnj;شود، داشتن زودپز مزیت بزرگی است. با توجه به اینکه زودپزهای برقی جدید امکان برنامه&zwnj;ریزی دارند، می&zwnj;توانید زمان مشخص برای تهیه غذا را وارد کنید و نیاز نیست نگران سوختن غذایتان باشید.</p>\r\n<h3>سخن آخر تحقیق در مورد لوازم خانگی</h3>\r\n<p>برای زندگی در آسایش وجود&nbsp;<strong><a href=\"https://barayekharid.com/how-to-buy-home-appliances-at-the-best-price/\">لوازم خانگی</a></strong>&nbsp;در منزل واجب و ضروری است. ما در این مقاله تحقیق در مورد لوازم خانگی مختلف را انجام دادیم. ابتدا تعریف جامعی از لوازم خانگی ارائه دادیم و سپس وسایل خانگی بزرگ و کوچک را شرح دادیم. ملزومات خانگی بزرگ اغلب با عنوان کالاهای سفید معروف شده&zwnj;اند. ما در این مقاله لیست جامعی از لوازم خانگی ضروری در قسمت&zwnj;های مختلف خانه را ارائه دادیم.</p>\r\n<p>همچنین برخی از لوازم برقی کاربردی در قلب خانه، یعنی آشپزخانه را بررسی کردیم. امیدواریم با مطالعه این مقاله آگاهی لازم در مورد لوازم خانگی موردنیازتان را کسب کرده باشید. با تصمیم نهایی خود می&zwnj;توانید به سایت برای خرید مراجعه کنید و با اطمینان کامل خرید خود را انجام دهید. انواع مختلف لوازم خانگی با کیفیت را می&zwnj;توانید به صورت مجازی مشاهده کرده و بعد از بررسی کامل کالا آن را به سبد خرید خود اضافه کنید و از خرید خودتان لذت ببرید.</p>\r\n</article>\r\n</li>\r\n</ul>", false, "لوازم خانگی، لوازم خانگی چیست، همه چیز درباره لوازم خانگی", "در تحقیق در مورد صنعت لوازم خانگی ما می‌خواهیم بدانیم لوازم خانگی چیست؟", "2024-06-28-08-15-53-Smeg-2019-kitchen-appliances-dolce-gabbana-7-978x652.jpg", "لوازم خانگی چیست؟ ", "لوازم خانگی چیست؟ ", new DateTime(2024, 6, 29, 7, 46, 14, 727, DateTimeKind.Local).AddTicks(5503), "در تحقیق در مورد صنعت لوازم خانگی ما می‌خواهیم بدانیم لوازم خانگی چیست؟ پاسخ این سؤال به کاربرد لوازم خانگی موردنظر بستگی دارد اما در حالت کلی می‌توان گفت لوازم خانگی، یک دستگاه و ماشین طراحی شده برای استفاده ویژه است. در فرهنگ لغت لوازم خانگی به عنوان دستگاهی اغلب الکتریکی که در خانه برای تمیزکاری، پخت‌وپز و… استفاده می‌شود، تعریف شده است. با توجه به این تعریف تقریباً هر دستگاهی در خانه که برای امور مختلف استفاده می‌شود، لوازم خانگی به شمار می‌آید.", "لوازم-خانگی-چیست؟", "لوازم خانگی چیست؟ " },
                    { 2L, "", 1L, new DateTime(2024, 6, 29, 7, 46, 14, 727, DateTimeKind.Local).AddTicks(5590), "<h2>تعریف دکوراسیون داخلی :&nbsp;</h2>\r\n<p>کوراسیون معنای هماهنگ سازی طراحی شده برای به وجود آوردن رنگ ها، اثاثیه ها و دیگر اشیای در یک بخش از محیط خانه و یا هر جای دیگر از ساختمان به روش شیک و هنرمندانه را طراحی دکوراسیون می گویند.<br>زمانی که حرف از چیدمان منزل به حساب می آید نقش یک دکوراتور داخلی را باید برای خود ایفا نمایید. با این حال، دکوراسیون داخلی مثل بقیه هنرها جذاب، جزکاری و ریزکاری و سایر تکنیک های متفاوتی است که به همین عنوان سلیقه ها و نیازهای دوران، در حال تغییر می باشند.<br>در تعریف های متعدد از دکوراسیون داخلی یک اتصال میان معماری و طراحی داخلی وجود دارد. طراحی داخلی مثل بقیه معماری های ساختمان و عنصرهای به کار رفته ساختمان در ارتباط است.<br>معماران داخلی همراه با دانش و تجربه و سابقه کاری خود به طراحی دکوراسیون می پردازند، به صورتی که برابری در فضا به وجود می آورند.<br>در دکوراسیون داخلی هنرهای مانند سبک و اصول وجود دارد ، که هر کدام از چیدمان های بر اساس سیلقه می باشد.<br>امروزه افراد بیشتر وقت خود را در فضای بسته می گذرانند به همین عنوان داشتن فضای بسته شاد باعث به وجود آمدن اوقات خسته ناپذیری است که در آن اتاق هستید.&nbsp;<br>به همین علت دکوراسیون داخلی با کیفیت مناسب، بهترین روش برای سود بخشیدن به وضعیت زندگی می باشد.<br>افرادی که علاقه خاصی به طراحی دارند و می خواهند به یک دکوراتور داخلی تبدیل شوند نیاز اولیه آن ها نیز گذراندن دوره های آموزشی طراحی دکوراسیون داخلی است.<br>در دوره های طراحی دکوراسیون داخلی شما را با انواع &nbsp;تاریخ هنر و معماری آشنا می کند و حتی کلیه سبک های و شیوه های مربوط به رشته طراحی داخلی آشنا می سازد. بسیاری از طراحان داخلی حرفه ای سبک هایی ویژه ای برای دیگران برای الگو گرفتن به جای گذاشته اند.</p>\r\n<h2>به عبارتی دیگر از تعریف طراحی دکوراسیون داخلی :&nbsp;</h2>\r\n<p>طراحی دکوراسیون داخلی مجموعه از عوامل مختلف از جمله فرم ها، نور، رنگ، بافت ، کف ، سقف، دیوار، عناصر کارکردی و تزیینی و مبلمان را در خود جای می دهد. در اصل این عناصر ابزار و وسایل کار برای طراح می باشند که همه به شکل هماهنگ و مناسب در یک طرح مربوطه قرار می گیرند.<br>طراحی دکوراسیون همانجور که از نامش پیداست میان معماری و طراحی قرار گرفته است، به صورتی که دارای جنبه های کاربردی، ساختاری و فنی می باشد.&nbsp;<br>استفاده از طراحی دکوراسیون داخلی روش کاربردی است که برای دست یابی به اهداف مورد نظر شامل پویایی و بهبود بخشیدن به زندگی می شود.</p>\r\n<h2>تاثیر رنگ در دکوراسیون داخلی :&nbsp;</h2>\r\n<p>بهترین ایده در دکوراسیون داخلی، رنگ ها می باشد. از این رو هر چه دیده می شود دارای رنگ هستند. متخصصان طراحی به این نتیجه رسیده اند که استفاده از رنگ های مختلف تاثیر مثبتی بر روی فشار خون، پایین آمدن استرس و افزایش انرژی دارد.&nbsp;<br>نکته بسیار مهم که به آن توجه می شود توجه کردن به جزییات دکوراسیون داخلی نقش بسیار اساسی در سلامت روان و ارزش کارایی فضا دارد.</p>\r\n<p><img style=\"height: 275px; width: 813px;\" src=\"https://fanpardazan.com/ckfinder/userfiles/images/q.jpg\" alt=\"مدرک آموزش گواهینامه دوره\"></p>\r\n<h2>عناصر مهم در دکوراسیون داخلی :</h2>\r\n<p>هنر دکوراسیون داخلی فقط به چیدن اشیا و اثاثیه محدود نمی شود و عناصر دیگر هم دخالت دارند. علاوه بر عوامل رنگ ، نور و چیدمان مبلمان ها ، روحیه افراد محیط و نیازهای آن ها به دقت بررسی می شود.</p>\r\n<h2>سبک های مختلف دکوراسیون داخلی :</h2>\r\n<p>برای طراحی داخلی اولین اقدام داشتن اطلاعات درباره انواع مختلف سبک های دکوراسیون است . سبک های مختلف شامل مدرن، مینیمال، اسکاندیناوی و صنعتی و ... می باشد که فرق های هم باهم دارند و هر کسی به علاقه خود در چیدن آن ها را برای محیط زندگی خود استفاده می کند.</p>\r\n<p>- سبک دکوراسیون مدرن :</p>\r\n<p>کلمه مدرن در زمینه دکوراسیون معمولا به یک خانه با رنگی ساده و منظم مثل استیل و شیشه طراحی می شود می گویند. در دکوراسیون مدرن عواملی مانند سادگی در همه جای منزل قابل مشاهده است و از ویژگی های سبک مدرن صاف، صیقلی و براق و شفاف دخالت دارند.</p>\r\n<p>2- سبک دکوراسیون امروزی :</p>\r\n<p>سبک مدرن و امروزی دو سبک متفاوت می باشد و اغلب به جای هم استفاده می شود. فرق بین آن ها در سبک مدرن شیوه طراحی است که در قرن بیستم شروع می شود.<br>از جهتی دیگر سبک امروزی انعطاف پذیری بالایی دارد و تعهد چندانی به سبک خاصی ندارد. در دکوراسیون امروزی راحتی در فضا موجود است.&nbsp;<br>بر عکس سبک مدرن فضای چیدمان راحتی در آن وجود ندارد و احساس صمیمیت بیشتری به مخاطب انتقال می دهد.</p>\r\n<p>3- سبک دکوراسیون مینیمال :&nbsp;</p>\r\n<p>سبک مینیمال یکی از انواع سبک های دکوراسیون داخلی است. در سبک مینیمالیست استفاده از پالت های رنگی مجاز می باشد و وسایل استفاده شده براق نمی باشد. در اصل سفید یکی از رنگ های پرکاربرد رنگ در دکوراسیون مینیمال است.<br>مینیمال به معنای سادگی و نبودن عنصرهای اضافی از محیط است.</p>\r\n<p>4- دکوراسیون صنعتی :&nbsp;<br>ایده سبک دکوراسیون از دوره انقلاب صنعتی اروپا ریشه گرفته است و منازل شهری قرن 17 و 18 میلادی در اروپا می باشد. در این نوع سبک استفاده از آجر و یا چوب در ظاهر دکوراسیون پرکاربرد است . یک خانه طراحی شده به روش صنعتی از یک روش استفاده شده از ساختمان صنعتی است.</p>\r\n<p>5- سبک دکوراسیون اسکاندیناوی :</p>\r\n<p>در طراحی سبک اسکاندیناوی وسایل استفاده شده در خانه همانند مبلمان از یک اثر هنری الهام گرفته شده است. این نوع سبک به سبک مینیمال نزدیک می باشد در اصل سبک مینیمال بیشتر ویژگی خود را از سبک اسکاندیناوی مدرن الهام می گیرد.</p>\r\n<p>6- سبک دکوراسیون فرانسوی :</p>\r\n<p>در سبک دکوراسیون فرانسوی استفاده از رنگ های گرم و ملایم مرسوم است. در میان انواع دیگر از سبک های دکوراسیون داخلی استفاده از ظرف های چینی نسبتا سنگین و ضخیم استفاده می شود.</p>\r\n<h2>مدرک طراحی دکوراسیون داخلی :</h2>\r\n<p>علاقمندان و افراد با داشتن مدرک طراحی دکوراسیون داخلی یک قدم از کسانی که فقط علاقه دارند نزدیک تر به این حرفه می باشند. چون در کنار هر علاقه داشتن مهارت و تمرین و بدست آوردن تجربه نیاز است به همین عنوان گذراندن دوره یکی از لزومات هر فرد برای هر رشته از جمله رشته طراحی دکوراسیون داخلی می باشد.</p>\r\n<h2>قانون دکوراسیون :</h2>\r\n<p>- حذف تابلوهای کوچک از دیوارهای بزرگ منزل :&nbsp;<br>برای بهترین چیدمان در منزل باید تابلوهای کوچک بر روی دیوارهای بزرگ را حذف کنیم با این کار دیوار خانه کوچک به نظر می رسد. برای این کار استفاده از تابلوهای دو سوم عریض تر از دیوار مناسب می باشد تا یک دکوراتیو به حساب آید.<br>-&nbsp;&nbsp; &nbsp;استفاه از تعداد نور مناسب در منزل :<br>استفاده از نورهای زرد ، میزان گرما و زردی به رنگ اضافه می کنند. در واقع، نورهای سفید سبب اضافه شدن کمی رنگ آبی به دیگر رنگ ها می گردد.</p>\r\n<p><img style=\"height: 275px; width: 813px;\" src=\"https://fanpardazan.com/ckfinder/userfiles/images/u.jpg\" alt=\"دوره آموزش گواهینامه مدرک\"></p>\r\n<p>&nbsp;</p>", false, "همه چیز درباره طراحی دکوراسیون داخلی، دکوراسیون داخلی، طراحی دکوراسیون داخلی، عناصر مهم در دکوراسیون", "در گذشته افراد با نقاشی کردن، طرح و نقش جذابی به غارهای خود می دادند. \r\nافراد ملل شرق، علاقه زیادی به دکوراسیون داخلی دارند. ذوق و شوق آن ها به مبلمان", "2024-06-29-00-24-46-دکوراسیون-داخلی-منزل-و-هرآنچه-باید-درباره-آن-بدانید.jpg", "همه چیز درباره طراحی دکوراسیون داخلی", "همه چیز درباره طراحی دکوراسیون داخلی", new DateTime(2024, 6, 29, 7, 46, 14, 727, DateTimeKind.Local).AddTicks(5584), "در گذشته افراد با نقاشی کردن، طرح و نقش جذابی به غارهای خود می دادند. \r\nافراد ملل شرق، علاقه زیادی به دکوراسیون داخلی دارند. ذوق و شوق آن ها به مبلمان و تزیینات چینی، فرش های ایرانی، صدف کاری ژاپنی و دیگر مجسمه ها و نقاشی و طرح های رنگی دارد که نشان دهنده جذابیت فضای زندگی شان است. سبک دکوراسیون در همه جای دنیا چه در شرق چه در غرب نیز متفاوت است.", "همه-چیز-درباره-طراحی-دکوراسیون-داخلی", "همه چیز درباره طراحی دکوراسیون داخلی" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategories");
        }
    }
}

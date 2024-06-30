using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.ProductAgg.Entities;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.ProductAgg
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(15).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();

            #region Relations 

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(p => p.Pictures).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);

            #endregion

            #region SeedData

            var product1 = new Product("گلدان سرامیکی سفید", "1", "گلدان بلند سفید سرامیکی مخصوص گل های آپارتمانی", "گلدان بلند سفید سرامیکی مخصوص گل های آپارتمانی", 3, "گلدان-سرامیکی-سفید", "گلدان سرامیکی سفید", "گلدان بلند سفید سرامیکی مخصوص گل های آپارتمانی");
            product1.Id = 1;
            builder.HasData(product1);

            var product2 = new Product("صندلی راحتی", "2", "صندلی راحتی پایه کوتاه از جنس لنین", "صندلی راحتی پایه کوتاه از جنس لنین", 2, "صندلی-راحتی", "صندلی راحتی پایه کوتاه", "صندلی راحتی پایه کوتاه از جنس لنین");
            product2.Id = 2;
            builder.HasData(product2);

            var product3 = new Product("صندلی پاف بدون پایه", "3", "صندلی پاف بدون پایه استوانه ای طرح سنتی ", "صندلی پاف بدون پایه استوانه ای طرح سنتی، داخل پشم شیشه.", 2, "صندلی-پاف-بدون-پایه", "صندلی پاف بدون پایه", "صندلی پاف بدون پایه استوانه ای طرح سنتی ");
            product3.Id = 3;
            builder.HasData(product3);


            var product4 = new Product("چراغ پایه بلند", "4", "چراغ پایه بلند با قابلیت کوتاه بلند کردن تا سقف 200 سانتی متر ", "چراغ پایه بلند با قابلیت کوتاه بلند کردن تا سقف 200 سانتی متر", 1, "چراغ-پایه-بلند", "چراغ پایه بلند", "چراغ پایه بلند با قابلیت کوتاه بلند کردن تا سقف 200 سانتی متر ");
            product4.Id = 4;
            builder.HasData(product4);

            var product5 = new Product("اورگانایزر پارچه ای", "5", "اوراگانایزر استوانه ای پارچه ای مخصوص لباس", "اوراگانایزر استوانه ای پارچه ای مخصوص لباس مدل HiMode\r\nمشخصات فنی : 27x27x27  سانتی متر\r\nجنس : نمد", 2, "اورگانایزر-پارچه-ای", "اورگانایزر پارچه ای", "اوراگانایزر استوانه ای پارچه ای مخصوص لباس ");
            product5.Id = 5;
            builder.HasData(product5);

            var product6 = new Product("چراغ سطلی", "6", "چراغ سطلی", "چراغ سطلی پایه کوتاه با ارتفاع 50 سانتی متر و لایتینک زرد، سفید و بنفشجنس : نمد", 1, "چراغ-سطلی", "چراغ سطلی", "چراغ سطلی پایه کوتاه ");
            product6.Id = 6;
            builder.HasData(product6);

            var product7 = new Product("گلدان پایه دار", "7", "گلدان پایه دار با پایه برنجی و جنس سرامیکی", "گلدان پایه دار با پایه برنجی و جنس سرامیکی با ارتفاع 200 سانتی متر", 3, "گلدان-پایه-دار", "گلدان پایه دار", "گلدان پایه دار با پایه برنجی و جنس سرامیکی ");
            product7.Id = 7;
            builder.HasData(product7);

            var product8 = new Product("استند گل", "8", "استند گل چوبی ", "استند گل چوبی با ارتفاع متغیر تا سقف 400 سانتی متر", 3, "استند-گل", "استند گل چوبی", "استند گل چوبی");
            product8.Id = 8;
            builder.HasData(product8);

            #endregion
        }
    }
}

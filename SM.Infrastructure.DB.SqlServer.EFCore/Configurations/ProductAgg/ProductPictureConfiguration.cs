using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.ProductAgg.Entities;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.ProductAgg
{
    public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.Property(p => p.PictureTitle).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PictureAlt).IsRequired().HasMaxLength(100);

            #region SeedData

            var picture1 = new ProductPicture(1, "4dcea8c370e84a4583dd11c36918db46.jpg", "گلدان سرامیکی سفید", "گلدان سرامیکی سفید");
            picture1.Id = 1;
            builder.HasData(picture1);

            var picture2 = new ProductPicture(1, "9409d0dde40c464eb10e81cdb7e819d9.jpg", "گلدان سرامیکی سفید", "گلدان سرامیکی سفید");
            picture2.Id = 2;
            builder.HasData(picture2);

            var picture3 = new ProductPicture(2, "47157c1ce82f4a9f9f325139056044bf.jpg", "صندلی  راحتی", "صندلی راحتی");
            picture3.Id = 3;
            builder.HasData(picture3);

            var picture4 = new ProductPicture(2, "8637033e7a324e4ea1f6aaf0a6809b83.jpg", "صندلی  راحتی", "صندلی راحتی");
            picture4.Id = 4;
            builder.HasData(picture4);

            var picture5 = new ProductPicture(3, "667bd11e85894f72ba29c3c1cdf6fb45.jpg", "صندلی پاف بدون پایه", "صندلی پاف بدون پایه");
            picture5.Id = 5;
            builder.HasData(picture5);

            var picture6 = new ProductPicture(4, "d7bce363d9cf413ca85582dab5019577.jpg", "چراغ پایه بلند", "چراغ پایه بلند");
            picture6.Id = 6;
            builder.HasData(picture6);

            var picture7 = new ProductPicture(5, "a1f312cb804247aa83042f508efd9b2e.jpg", "اورگانایزر پارچه ای", "اورگانایزر پارچه ای");
            picture7.Id = 7;
            builder.HasData(picture7);

            var picture8 = new ProductPicture(6, "1611d83ade5946bdb99dc033d8cd5940.jpg", "چراغ سطلی", "چراغ سطلی");
            picture8.Id = 8;
            builder.HasData(picture8);

            var picture9 = new ProductPicture(6, "e7e81158e93d4ffaa146e5f9bc6cbdce.jpg", "چراغ سطلی", "چراغ سطلی");
            picture9.Id = 9;
            builder.HasData(picture9);

            var picture10 = new ProductPicture(7, "5ad0368c3d1a4684abd4bd8bb72e3700.jpg", "گلدان پایه دار", "گلدان پایه دار");
            picture10.Id = 10;
            builder.HasData(picture10);

            var picture11 = new ProductPicture(7, "af08b9d21c2f4d2bb582a8d67865129e.jpg", "گلدان پایه دار", "گلدان پایه دار");
            picture11.Id = 11;
            builder.HasData(picture11);

            var picture12 = new ProductPicture(8, "7408008595fc46879ab174b54e5f5141.jpg", "استند گل", "استند گل");
            picture12.Id = 12;
            builder.HasData(picture12);

            var picture13 = new ProductPicture(8, "42f851066cbc457f964c3ef01545ce1d.jpg", "استند گل", "استند گل");
            picture13.Id = 13;
            builder.HasData(picture13);

            var picture14 = new ProductPicture(3, "d73fe5a82d26447f8022d0cfd6448e95.jpg", "صندلی پاف بدون پایه", "صندلی پاف بدون پایه");
            picture14.Id = 14;
            builder.HasData(picture14);

            #endregion
        }
    }
}

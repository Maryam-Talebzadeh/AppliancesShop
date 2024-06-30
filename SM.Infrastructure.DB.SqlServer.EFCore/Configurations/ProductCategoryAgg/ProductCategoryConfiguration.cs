using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.ProductCategoryAgg
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(pc => pc.Name).HasMaxLength(255).IsRequired();
            builder.Property(pc => pc.Description).HasMaxLength(500);
            builder.Property(pc => pc.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(pc => pc.MetaDescription).HasMaxLength(80).IsRequired();
            builder.Property(pc => pc.Slug).HasMaxLength(300).IsRequired();

            #region Relations

            builder.HasOne(pc => pc.Picture).WithOne(p => p.ProductCategory).HasForeignKey<ProductCategory>(pc => pc.PictureId);

            #endregion

            #region SeedData

            var category1 = new ProductCategory("دکوری", "انواع لوازم دکوری خانه", "انواع لوازم دکوری خانه", "دکوری", "لوازم دکوری",1);
            category1.Id = 1;
            builder.HasData(category1);

            var category2 = new ProductCategory("راحتی", "انواع لوازم راحتی خانه", "انواع لوازم راحتی خانه", "راحتی", "لوازم راحتی", 2);
            category2.Id = 2;
            builder.HasData(category2);

            var category3 = new ProductCategory("گلدان", "انواع گلدان های سرامیکی و سفالی", "انواع گلدان های سرامیکی و سفالی", "گلدان", "گلدان", 3);
            category3.Id = 3;
            builder.HasData(category3);

            #endregion
        }
    }
}

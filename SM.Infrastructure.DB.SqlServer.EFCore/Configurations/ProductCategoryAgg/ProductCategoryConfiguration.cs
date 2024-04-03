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



            #endregion

        }
    }
}

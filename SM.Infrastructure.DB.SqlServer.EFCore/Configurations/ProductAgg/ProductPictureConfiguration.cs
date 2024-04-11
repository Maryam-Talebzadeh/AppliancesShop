using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.ProductAgg
{
    public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.Property(p => p.PictureTitle).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PictureAlt).IsRequired().HasMaxLength(100);
        }
    }
}

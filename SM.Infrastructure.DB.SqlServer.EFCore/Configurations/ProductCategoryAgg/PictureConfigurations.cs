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
    public class PictureConfigurations : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(1000);
            builder.Property(p => p.Title).HasMaxLength(500);
            builder.Property(p => p.Alt).HasMaxLength(255);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            #region SeedData

            var picture1 = new Picture("cf827bdd90884e36aee3fecd26617036.jpg", "دکوری", "دکوری");
            picture1.Id = 1;
            builder.HasData(picture1);

            var picture2 = new Picture("6ca4f38a6635446db326f54283659b2e.jpg", "راحتی", "راحتی");
            picture2.Id = 2;
            builder.HasData(picture2);

            var picture3 = new Picture("e6f462ad8ec14614accc243ebf42558e.jpg", "گلدان", "گلدان");
            picture3.Id = 3;
            builder.HasData(picture3);

            #endregion
        }
    }
}

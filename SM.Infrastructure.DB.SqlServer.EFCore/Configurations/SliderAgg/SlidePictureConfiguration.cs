using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.SliderAgg.Entities;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.SliderAgg
{
    public class SlidePictureConfiguration : IEntityTypeConfiguration<SlidePicture>
    {
        public void Configure(EntityTypeBuilder<SlidePicture> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Alt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();

            #region SeedData

            var pic1 = new SlidePicture("5099b0fa6ac04deca0452dd70bedb89a.jpg", "مبل", "مبل");
            pic1.Id = 1;
           builder.HasData(pic1);

            var pic2 = new SlidePicture("6aef82656ec6439388b7d50739a65f87.jpg", "ساعت", "ساعت");
            pic2.Id = 2;
            builder.HasData(pic2);

            #endregion 
        }
    }
}

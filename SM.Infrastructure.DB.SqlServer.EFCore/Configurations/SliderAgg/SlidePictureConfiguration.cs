using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.SliderAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.SliderAgg
{
    public class SlidePictureConfiguration : IEntityTypeConfiguration<SlidePicture>
    {
        public void Configure(EntityTypeBuilder<SlidePicture> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Alt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
        }
    }
}

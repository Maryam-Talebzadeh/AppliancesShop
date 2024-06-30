using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.Core.SliderAgg.Entities;

namespace SM.Infrastructure.DB.SqlServer.EFCore.Configurations.SliderAgg
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.Text).HasMaxLength(255);
            builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();

            #region Relations

            builder.HasOne(s => s.Picture).WithOne(p => p.Slide).HasForeignKey<Slide>(s => s.PictureId);

            #endregion

            #region SeedData

            var slide1 = new Slide(1, "دنبال قشنگ کردن خونتی؟", "ما با 40 درصد تخفیف کمکت میکنیم", "تا جمعه وقت داری با 40 درصد تخفیف خونتو قشنگ تر کنی", "اینجا کلیک کن", "#Products");
            slide1.Id = 1;
            builder.HasData(slide1);

            var slide2 = new Slide(2, "میخوای کادو بخری؟", "با 30 درصد تخفیف کادو بخر", "ما واسه یه سری لوازم دکوری تخفیف 30 درصد زدیم. از دستش نده", "کلیک کن", "#Products");
            slide2.Id = 2;
            builder.HasData(slide2);

            #endregion

        }
    }
}

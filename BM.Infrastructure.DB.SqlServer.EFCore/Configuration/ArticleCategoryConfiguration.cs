using BM.Domain.Core.ArticleCategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.Keywords).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).HasMaxLength(150);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);


            #region SeedData

            var category = new ArticleCategory("لوازم خانگی", "2024-06-27-16-02-13-Sage-Green-Electrics-Collection-1200x675.jpg", "لوازم خانگی", "لوازم خانگی", "مقالات درباره لوازم خانگی", 1, "لوازم-خانگی", "لوازم خانگی", "مقالات درباره لوازم خانگی", "");
            category.Id = 1;
            builder.HasData(category);

            #endregion

        }
    }
}

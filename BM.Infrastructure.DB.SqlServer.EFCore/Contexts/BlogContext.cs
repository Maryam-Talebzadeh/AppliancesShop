using BM.Domain.Core.ArticleAgg.Entities;
using BM.Domain.Core.ArticleCategoryAgg.Entities;
using BM.Infrastructure.DB.SqlServer.EFCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
   public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

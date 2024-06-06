using BM.Domain.Core.ArticleCategoryAgg.Entities;
using BM.Infrastructure.DB.SqlServer.EFCore.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    internal class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

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

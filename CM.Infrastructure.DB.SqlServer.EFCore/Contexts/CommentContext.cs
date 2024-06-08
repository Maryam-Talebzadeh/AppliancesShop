using CM.Domain.Core.CommentAgg.Entities;
using CM.Infrastructure.DB.SqlServer.EFCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class CommentContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

using CM.Domain.Core.CommentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Email).HasMaxLength(500);
            builder.Property(x => x.Website).HasMaxLength(500);
            builder.Property(x => x.Message).HasMaxLength(1000);
        }
    }
}

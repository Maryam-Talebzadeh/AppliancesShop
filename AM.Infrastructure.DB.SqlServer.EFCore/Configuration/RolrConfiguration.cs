using AM.Domain.Core.RoleAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class RolrConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}

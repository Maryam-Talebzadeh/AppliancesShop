using AM.Domain.Core.RoleAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            #region Seed Data

            builder.OwnsMany(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.ToTable("RolePermissions");
                navigationBuilder.Ignore(x => x.Name);
                navigationBuilder.WithOwner(x => x.Role);
            });

            #endregion
        }
    }
}

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

            #region Own

            builder.OwnsMany(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.ToTable("RolePermissions");
                navigationBuilder.Ignore(x => x.Name);
                navigationBuilder.WithOwner(x => x.Role);
            });

            #endregion

            #region SeedData

            var role1 = new Role("مدیرسیستم", new List<Permission>());
            role1.Id = 1;
            builder.HasData(role1);

            var role2 = new Role("کاربر عادی", new List<Permission>());
            role2.Id = 2;
            builder.HasData(role2);

            var role3 = new Role("محتوا گذار", new List<Permission>());
            role3.Id = 3;
            builder.HasData(role3);

            #endregion
        }
    }
}

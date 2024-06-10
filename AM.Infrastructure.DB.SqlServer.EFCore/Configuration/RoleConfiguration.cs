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

            var role1 = new Role("مدیرسیستم");
            role1.Id = 1;
            builder.HasData(role1);

            var role2 = new Role("کاربر عادی");
            role2.Id = 2;
            builder.HasData(role2);

            var role3 = new Role("محتوا گذار");
            role3.Id = 3;
            builder.HasData(role3);

            #endregion
        }
    }
}

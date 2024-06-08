using AM.Domain.Core.AccountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Fullname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ProfilePhoto).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(20).IsRequired();
        }
    }
}

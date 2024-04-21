

using IM.Domain.Core.InventoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IM.Infrastructure.DB.SqlServer.EFCore.Configurations.InventoryAgg
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            #region Own

            builder.OwnsMany(i => i.Operations, modelBuilder =>
            {
                modelBuilder.Property(o => o.Description).HasMaxLength(1000);
                modelBuilder.WithOwner(o => o.Inventory).HasForeignKey(o => o.InventoryId);
            });

            #endregion
        }
    }
}

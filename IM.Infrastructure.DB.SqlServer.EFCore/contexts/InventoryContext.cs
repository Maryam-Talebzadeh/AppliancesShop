using IM.Domain.Core.InventoryAgg.Entities;
using IM.Infrastructure.DB.SqlServer.EFCore.Configurations.InventoryAgg;
using Microsoft.EntityFrameworkCore;

namespace IM.Infrastructure.DB.SqlServer.EFCore.contexts
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
            
        }

        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryOperation> InventoryOperations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

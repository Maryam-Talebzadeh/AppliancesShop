using DM.Domain.Core.CustomerDiscountAgg.Entities;
using DM.Infrastructure.DB.SqlServer.EFCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) :base(options)
        {
            
        }

        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

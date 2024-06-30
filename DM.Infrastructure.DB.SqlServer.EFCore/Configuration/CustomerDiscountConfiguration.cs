using DM.Domain.Core.CustomerDiscountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class CustomerDiscountConfiguration : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.Property(x => x.Reason).HasMaxLength(500);

            #region SeedData

            var discount1 = new CustomerDiscount(4, 40, DateTime.Now, DateTime.Now.AddMonths(1), "جشنواره");
            discount1.Id = 1;
            builder.HasData(discount1);

            var discount2 = new CustomerDiscount(3, 25, DateTime.Now, DateTime.Now.AddMonths(1), "جشنواره");
            discount2.Id = 2;
            builder.HasData(discount2);

            var discount3 = new CustomerDiscount(1, 10, DateTime.Now, DateTime.Now.AddMonths(1), "جشنواره");
            discount3.Id = 3;
            builder.HasData(discount3);

            #endregion
        }
    }
}

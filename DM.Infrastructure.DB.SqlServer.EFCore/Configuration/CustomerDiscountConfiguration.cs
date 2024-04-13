using DM.Domain.Core.CustomerDiscountAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class CustomerDiscountConfiguration : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.Property(x => x.Reason).HasMaxLength(500);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace DM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) :base(options)
        {
            
        }
    }
}

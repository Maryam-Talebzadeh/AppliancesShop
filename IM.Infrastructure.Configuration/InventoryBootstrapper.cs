using IM.Domain.Core.InventoryAgg.Data;
using IM.Infrastructure.DB.SqlServer.EFCore.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IM.Infrastructure.DataAccess.Repos.EFCore.InventoryAgg;

namespace IM.Infrastructure.Configuration
{
    public class InventoryBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IInventoryRepository, InventoryRepository>();

            #region DbContext

            services.AddDbContext<InventoryContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion
        }
    }
}

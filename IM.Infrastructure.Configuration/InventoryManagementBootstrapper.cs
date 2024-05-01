using IM.Domain.Core.InventoryAgg.Data;
using IM.Infrastructure.DB.SqlServer.EFCore.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IM.Infrastructure.DataAccess.Repos.EFCore.InventoryAgg;
using IM.Domain.Core.InventoryAgg.Services;
using IM.Domain.Services.InventoryAgg;
using IM.Domain.Core.InventoryAgg.AppServices;
using IM.Domain.AppServices.InventoryAgg;

namespace IM.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryAppService, InventoryAppService>();

            #region DbContext

            services.AddDbContext<InventoryContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.Services;
using SM.Domain.Services.ProductCategoryAgg;
using SM.Infrastructure.DataAccess.Repos.EFCore.ProductCategoryAgg;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace SM.Infrastructure.Configuration
{
    public class SMBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            #region DbContext

            services.AddDbContext<ShopContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion
        }


    }
}

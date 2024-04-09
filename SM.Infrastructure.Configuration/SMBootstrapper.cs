using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SM.Domain.AppServices.ProductCategoryAgg;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.Services;
using SM.Domain.Core.ProductCategoryAgg.AppServices;
using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.Services;
using SM.Domain.Services.ProductAgg;
using SM.Domain.Services.ProductCategoryAgg;
using SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg;
using SM.Infrastructure.DataAccess.Repos.EFCore.ProductCategoryAgg;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace SM.Infrastructure.Configuration
{
    public class SMBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            #region Product Category

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductCategoryAppService, ProductCategoryAppService>();
            services.AddScoped<IPictureRepository, PictureRepository>();

            #endregion

            #region Product

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            #endregion

            #region DbContext

            services.AddDbContext<ShopContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion
        }


    }
}

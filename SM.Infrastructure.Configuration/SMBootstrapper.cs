﻿using Base_Framework.Domain.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Infrastructure.AccountAcl;
using SiteManagement.Infrastructure.InventoryAcl;
using SM.Domain.AppServices.OrderAgg;
using SM.Domain.AppServices.ProductAgg;
using SM.Domain.AppServices.ProductCategoryAgg;
using SM.Domain.AppServices.SliderAgg;
using SM.Domain.Core._0_Services;
using SM.Domain.Core.OrderAgg.AppServices;
using SM.Domain.Core.OrderAgg.Data;
using SM.Domain.Core.OrderAgg.Services;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.Services;
using SM.Domain.Core.ProductCategoryAgg.AppServices;
using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.Services;
using SM.Domain.Core.SliderAgg.AppServices;
using SM.Domain.Core.SliderAgg.Data;
using SM.Domain.Core.SliderAgg.Services;
using SM.Domain.Services.OrderAgg;
using SM.Domain.Services.ProductAgg;
using SM.Domain.Services.ProductCategoryAgg;
using SM.Domain.Services.SlideAgg;
using SM.Infrastructure.Configuration.Permissions;
using SM.Infrastructure.DataAccess.Repos.EFCore.OrderAgg;
using SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg;
using SM.Infrastructure.DataAccess.Repos.EFCore.ProductCategoryAgg;
using SM.Infrastructure.DataAccess.Repos.EFCore.SliderAgg;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace SM.Infrastructure.Configuration
{
    public class SiteManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            #region Order


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderAppService, OrderAppService>();

            #endregion

            #region Product Category

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductCategoryAppService, ProductCategoryAppService>();
            services.AddScoped<IPictureRepository, PictureRepository>();

            #endregion

            #region Product

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductAppService, ProductAppService>();

            services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
            services.AddScoped<IProductPictureService, ProductPictureService>();
            services.AddScoped<IProductPictureAppService, ProductPictureAppService>();

            #endregion

            #region Slider

            services.AddScoped<ISlideRepository, SlideRepository>();
            services.AddScoped<ISlideService, SlideService>();
            services.AddScoped<ISlideAppService, SlideAppService>();

            services.AddScoped<ISlidePictureRepository, SlidePictureRepository>();
            services.AddScoped<ISlidePictureService, SlidePictureService>();

            #endregion

            #region DbContext

            services.AddDbContext<ShopContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion

            services.AddSingleton<IPermissionExposer, ShopPermissionExposer>();
            services.AddSingleton<ICartService, CartService>();
            services.AddScoped<ISiteInventoryAcl, SiteInventoryAcl>();
            services.AddScoped<ISiteAccountAcl, SiteAccountAcl>();
        }


    }
}

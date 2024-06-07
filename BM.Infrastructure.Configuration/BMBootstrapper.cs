using BM.Domain.AppServices.ArticleCategoryAgg;
using BM.Domain.Core.ArticleCategoryAgg.AppServices;
using BM.Domain.Core.ArticleCategoryAgg.Data;
using BM.Domain.Core.ArticleCategoryAgg.Services;
using BM.Domain.Services.ArticleCategoryAgg;
using BM.Infrastructure.DataAccess.Repos.EFCore.ArticleCategoryAgg;
using BM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BM.Infrastructure.Configuration
{
   public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<IArticleCategoryService, ArticleCategoryService>();
            services.AddScoped<IArticleCategoryAppService, ArticleCategoryAppService>();

            #region DbContext

            services.AddDbContext<BlogContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion
        }
    }
}

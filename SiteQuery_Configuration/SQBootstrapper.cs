using Base_Framework.Domain.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Queries;
using SiteQuery_EfCore.Contracts;
using SiteQuery_EfCore.Queries;

namespace SiteQuery_Configuration
{
    public class SiteQueryBootstrapper
    {
        public static string ConnectionString { get; set; }

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductCategoryQuery>(provider => new ProductCategoryQuery(connectionString));
            services.AddScoped<IProductQuery>(provider => new ProductQuery(connectionString));
            services.AddScoped<IArticleQuery>(provider => new ArticleQuery(connectionString));
            services.AddScoped<IArticleCategoryQuery>(provider => new ArticleCategoryQuery(connectionString));
            services.AddScoped<ICartCalculatorService>(provider => new CartCalculatorService(connectionString));
            services.AddScoped<IChartQuery, ChartQuery>();
        }
    }
}

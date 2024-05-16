using Microsoft.Extensions.DependencyInjection;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Queries;

namespace SiteQuery_Configuration
{
    public class SQBootstrapper
    {
        public static string ConnectionString { get; set; }

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductCategoryQuery>(provider => new ProductCategoryQuery(connectionString));
        }
    }
}

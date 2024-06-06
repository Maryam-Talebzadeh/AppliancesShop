using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Base_Framework.Configuration
{
    public class BaseFrameworkBootstrapper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IFileUploader, FileUploader>();

        }
    }
}

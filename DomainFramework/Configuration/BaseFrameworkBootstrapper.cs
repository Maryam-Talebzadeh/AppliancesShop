using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Core.Contracts.ZarinPal;
using Base_Framework.Domain.Services;
using Base_Framework.Domain.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Base_Framework.Configuration
{
    public class BaseFrameworkBootstrapper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IZarinPalFactory, ZarinPalFactory>();
            services.AddSingleton<ISmsService, SmsService>(); 
        }
    }
}

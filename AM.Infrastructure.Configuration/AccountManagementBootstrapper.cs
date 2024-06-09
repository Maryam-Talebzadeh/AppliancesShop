using AM.Domain.AppServices.AccountAgg;
using AM.Domain.Core.AccountAgg.AppServices;
using AM.Domain.Core.AccountAgg.Data;
using AM.Domain.Core.AccountAgg.Services;
using AM.Domain.Services.AccountService;
using AM.Infrastructure.DataAccess.Repos.EFCore.AccountAgg;
using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Infrastructure.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountAppService, AccountAppService>();


            #region DbContext

            services.AddDbContext<AccountContext>(options =>
            options.UseSqlServer(connectionString)
            );

            #endregion
        }
    }
}

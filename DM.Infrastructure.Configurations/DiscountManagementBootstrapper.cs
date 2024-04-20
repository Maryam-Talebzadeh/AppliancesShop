
using DM.Domain.AppServices.ColleagueDiscountAgg;
using DM.Domain.AppServices.CustomerDiscountAgg;
using DM.Domain.Core.ColleagueDiscountAgg.AppServices;
using DM.Domain.Core.ColleagueDiscountAgg.Data;
using DM.Domain.Core.ColleagueDiscountAgg.Services;
using DM.Domain.Core.CustomerDiscountAgg.AppSevices;
using DM.Domain.Core.CustomerDiscountAgg.Data;
using DM.Domain.Core.CustomerDiscountAgg.Sevices;
using DM.Domain.Services.ColleagueDiscountAgg;
using DM.Domain.Services.CustomerDiscountAgg;
using DM.Infrastructure.DataAccess.Repos.EFCore.ColleagueDiscountAgg;
using DM.Infrastructure.DataAccess.Repos.EFCore.CustomerDiscountAgg;
using DM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace DM.Infrastructure.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            #region CustomerDiscount

            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddScoped<ICustomerDiscountService, CustomerDiscountService>();
            services.AddScoped<ICustomerDiscountAppService, CustomerDiscountAppService>();

            #endregion

            #region ColleagueDiscount

            services.AddScoped<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            services.AddScoped<IColleagueDiscountService, ColleagueDiscountService>();
            services.AddScoped<IColleagueDiscountAppService, ColleagueDiscountAppService>();

            #endregion

            #region DBContext

            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));

            #endregion
        }
    }
}

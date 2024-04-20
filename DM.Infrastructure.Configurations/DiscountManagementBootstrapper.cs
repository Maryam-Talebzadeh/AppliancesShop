
using DM.Domain.AppServices.CustomerDiscountAgg;
using DM.Domain.Core.CustomerDiscountAgg.AppSevices;
using DM.Domain.Core.CustomerDiscountAgg.Data;
using DM.Domain.Core.CustomerDiscountAgg.Sevices;
using DM.Domain.Services.CustomerDiscountAgg;
using DM.Infrastructure.DataAccess.Repos.EFCore.CustomerDiscountAgg;
using DM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Infrastructure.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddScoped<ICustomerDiscountService, CustomerDiscountService>();
            services.AddScoped<ICustomerDiscountAppService, CustomerDiscountAppService>();

            #region DBContext

            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));

            #endregion
        }
    }
}

using CM.Domain.AppServices.CommentAgg;
using CM.Domain.Core.CommentAgg.AppServices;
using CM.Domain.Core.CommentAgg.Data;
using CM.Domain.Core.CommentAgg.Services;
using CM.Domain.Services.CommentAgg;
using CM.Infrastructure.DataAccess.Repos.EFCore.CommentAgg;
using CM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrastructure.Configuration
{
    public class CommentManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentAppService, CommentAppService>();
       

            #region DBContext

            services.AddDbContext<CommentContext>(x => x.UseSqlServer(connectionString));

            #endregion
        }
    }
}

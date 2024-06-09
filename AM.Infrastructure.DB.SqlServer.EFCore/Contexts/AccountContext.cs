using AM.Domain.Core.AccountAgg.Entities;
using AM.Domain.Core.RoleAgg.Entities;
using AM.Infrastructure.DB.SqlServer.EFCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

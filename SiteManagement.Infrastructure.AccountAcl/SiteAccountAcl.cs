using AM.Domain.Core.AccountAgg.AppServices;
using SM.Domain.Core._0_Services;

namespace SiteManagement.Infrastructure.AccountAcl
{
   public class SiteAccountAcl : ISiteAccountAcl
    {
        private readonly IAccountAppService _accountAppService;

        public SiteAccountAcl(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public async Task<(string name, string mobile)> GetAccountBy(long id, CancellationToken cancellationToken)
        {
            var account = await _accountAppService.GetAccountBy(id, cancellationToken);
            return (account.Fullname, account.Mobile);
        }
    }
}

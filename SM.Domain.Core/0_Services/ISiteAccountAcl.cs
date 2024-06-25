

namespace SM.Domain.Core._0_Services
{
   public interface ISiteAccountAcl
    {
        Task<(string name, string mobile)> GetAccountBy(long id, CancellationToken cancellationToken);
    }
}

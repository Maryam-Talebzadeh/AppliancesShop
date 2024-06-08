using AM.Domain.Core.AccountAgg.DTOs;
using AM.Domain.Core.AccountAgg.Entities;
using Base_Framework.Domain.Core.Contracts;

namespace AM.Domain.Core.Data
{
   public interface IAccountRepository : IRepository<Account>
    {
        Task ChangePassword(ChangePasswordDTO changePasswordDTO, CancellationToken cancellationToken);
        Task Create(RegisterAccountDTO registerAccountDTO, CancellationToken cancellationToken);
        Task Edit(EditAccountDTO editAccountDTO, CancellationToken cancellationToken);
        Task<AccountDTO> GetBy(string username, CancellationToken cancellationToken);
        Task<EditAccountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<AccountDTO>> GetAccounts(CancellationToken cancellationToken);
        Task<List<AccountDTO>> Search(SearchAccountDTO searchModel, CancellationToken cancellationToken);
    }
}

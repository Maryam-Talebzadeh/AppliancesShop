using AM.Domain.Core.AccountAgg.DTOs;
using Base_Framework.Domain.Services;

namespace AM.Domain.Core.AccountAgg.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountBy(long id, CancellationToken cancellationToken);
        Task<OperationResult> Register(RegisterAccountDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditAccountDTO command, CancellationToken cancellationToken);
        Task<OperationResult> ChangePassword(ChangePasswordDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Login(LoginAccountDTO command, CancellationToken cancellationToken);
        Task<EditAccountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<AccountDTO>> Search(SearchAccountDTO searchModel, CancellationToken cancellationToken);
        Task<List<AccountDTO>> GetAccounts(CancellationToken cancellationToken);
        Task<AccountDTO> GetBy(string username, CancellationToken cancellationToken);
        Task<List<int>> GetPermissionsCodeBy(long roleId, CancellationToken cancellationToken);
    }
}

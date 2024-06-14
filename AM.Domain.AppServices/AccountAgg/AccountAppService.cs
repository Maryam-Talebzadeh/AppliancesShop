using AM.Domain.Core.AccountAgg.AppServices;
using AM.Domain.Core.AccountAgg.DTOs;
using AM.Domain.Core.AccountAgg.Services;
using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;

namespace AM.Domain.AppServices.AccountAgg
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountService _accountService;
        private readonly IAuthHelper _authHelper;

        public AccountAppService(IAccountService accountService, IAuthHelper authHelper)
        {
            _accountService = accountService;
            _authHelper = authHelper;

        }

        public async Task<OperationResult> ChangePassword(ChangePasswordDTO command, CancellationToken cancellationToken)
        {
          return await _accountService.ChangePassword(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditAccountDTO command, CancellationToken cancellationToken)
        {
            return await _accountService.Edit(command, cancellationToken);
        }

        public async Task<AccountDTO> GetAccountBy(long id, CancellationToken cancellationToken)
        {
            return await _accountService.GetAccountBy(id, cancellationToken);
        }

        public async Task<List<AccountDTO>> GetAccounts(CancellationToken cancellationToken)
        {
            return await _accountService.GetAccounts(cancellationToken);
        }

        public async Task<EditAccountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _accountService.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Login(LoginAccountDTO command, CancellationToken cancellationToken)
        {
           var result =  await _accountService.Login(command, cancellationToken);
            var account = await _accountService.GetBy(command.Username, cancellationToken);

            if (result.IsSuccedded)
            {
                var permissions = await _accountService.GetPermissionsCodeBy(account.RoleId, cancellationToken);
                var authViewModel = new AuthDTO(account.Id, account.RoleId, account.Fullname
                , account.Username, account.Mobile, permissions);

               await _authHelper.Signin(authViewModel, cancellationToken);
                return result.Succedded();
            }

            return result;
        }

        public async Task Logout(CancellationToken cancellationToken)
        {
            await _authHelper.SignOut(cancellationToken);
        }

        public async Task<OperationResult> Register(RegisterAccountDTO command, CancellationToken cancellationToken)
        {
            return await _accountService.Register(command, cancellationToken);
        }

        public async Task<List<AccountDTO>> Search(SearchAccountDTO searchModel, CancellationToken cancellationToken)
        {
            return await _accountService.Search(searchModel, cancellationToken);
        }
    }
}

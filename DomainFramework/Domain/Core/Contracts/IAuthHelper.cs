namespace Base_Framework.Domain.Core.Contracts
{
    public interface IAuthHelper
    {
        Task SignOut(CancellationToken cancellationToken);
        bool IsAuthenticated();
        Task Signin(AuthDTO account, CancellationToken cancellationToken);
       string CurrentAccountRole();
        Task<AuthDTO> CurrentAccountInfo(CancellationToken cancellationToken);
        long CurrentAccountId();
        Task<string> CurrentAccountMobile(CancellationToken cancellationToken);
        List<int> GetPermissions();
    }
}

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IAuthHelper
    {
        Task SignOut(CancellationToken cancellationToken);
        bool IsAuthenticated();
        Task Signin(AuthDTO account, CancellationToken cancellationToken);
       string CurrentAccountRole();
        AuthDTO CurrentAccountInfo();
        long CurrentAccountId();
        Task<string> CurrentAccountMobile(CancellationToken cancellationToken);
        List<int> GetPermissions();
    }
}

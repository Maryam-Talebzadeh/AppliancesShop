namespace Base_Framework.Domain.Core.Contracts
{
    public interface IAuthHelper
    {
        Task SignOut(CancellationToken cancellationToken);
        bool IsAuthenticated();
        Task Signin(AuthDTO account, CancellationToken cancellationToken);
        Task<string> CurrentAccountRole(CancellationToken cancellationToken);
        Task<AuthDTO> CurrentAccountInfo(CancellationToken cancellationToken);
        Task<long> CurrentAccountId(CancellationToken cancellationToken);
        Task<string> CurrentAccountMobile(CancellationToken cancellationToken);
        List<int> GetPermissions();
    }
}

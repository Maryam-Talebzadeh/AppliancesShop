

namespace Base_Framework.Domain.Core.Contracts
{
    public interface ISmsService
    {
        Task Send(string number, string message, CancellationToken cancellationToken);
    }
}

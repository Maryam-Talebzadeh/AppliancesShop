using Base_Framework.Domain.Core.Contracts;
using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface ICartCalculatorService
    {
        Task<CartQueryModel> ComputeCart(List<CartItemQueryModel> cartItems, CancellationToken cancellationToken, IAuthHelper authHelper);
    }
}

using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace SM.Domain.Core.OrderAgg.Services
{
    public interface ICartService
    {
        Task<CartDTO> Get(CancellationToken cancellationToken);
        Task Set(CartDTO cart, CancellationToken cancellationToken);
    }
}

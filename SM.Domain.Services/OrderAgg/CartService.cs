using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Services;

namespace SM.Domain.Services.OrderAgg
{
    public class CartService : ICartService
    {
        public CartDTO Cart { get; set; }
        public async Task<CartDTO> Get(CancellationToken cancellationToken)
        {
            return Cart;
        }

        public async Task Set(CartDTO cart, CancellationToken cancellationToken)
        {
            Cart = cart;
        }
    }
}

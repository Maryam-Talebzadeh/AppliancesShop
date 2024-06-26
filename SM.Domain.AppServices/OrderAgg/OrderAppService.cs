using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using SM.Domain.Core._0_Services;
using SM.Domain.Core.OrderAgg.AppServices;
using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Entities;
using SM.Domain.Core.OrderAgg.Services;

namespace SM.Domain.AppServices.OrderAgg
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IAuthHelper _authHelper;
       

        public OrderAppService(IOrderService orderService, IAuthHelper authHelper)
        {
            _orderService = orderService;
            _authHelper = authHelper;
        }

        public async Task Cancel(long id, CancellationToken cancellationToken)
        {
           await _orderService.Cancel(id, cancellationToken);
        }

        public async Task<double> GetAmountBy(long id, CancellationToken cancellationToken)
        {
            return await _orderService.GetAmountBy(id, cancellationToken);
        }

        public async Task<List<OrderItemDTO>> GetItems(long orderId, CancellationToken cancellationToken)
        {
            return await _orderService.GetItems(orderId, cancellationToken);
        }

        public async Task<string> PaymentSucceeded(long orderId, long refId, CancellationToken cancellationToken)
        {
            return await _orderService.PaymentSucceeded(orderId, refId, cancellationToken);
        }

        public async Task<long> PlaceOrder(CartDTO cart, CancellationToken cancellationToken)
        {
            cart.AccountId = _authHelper.CurrentAccountId();
            return await _orderService.PlaceOrder(cart, cancellationToken);
        }

        public async Task<List<OrderDTO>> Search(SearchOrderDTO searchModel, CancellationToken cancellationToken)
        {
            return await _orderService.Search(searchModel, cancellationToken);
        }
    }
}

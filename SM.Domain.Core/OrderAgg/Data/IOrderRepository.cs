using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace SM.Domain.Core.OrderAgg.Data
{
   public  interface IOrderRepository
    {
        Task<long> PlaceOrder(CartDTO cart, CancellationToken cancellationToken);
        Task<double> GetAmountBy(long id, CancellationToken cancellationToken);
        Task Cancel(long id, CancellationToken cancellationToken);
        Task<string> PaymentSucceeded(long orderId, long refId, CancellationToken cancellationToken);
        Task<List<OrderItemDTO>> GetItems(long orderId, CancellationToken cancellationToken);
        Task<List<OrderDTO>> Search(SearchOrderDTO searchModel, CancellationToken cancellationToken);
    }
}

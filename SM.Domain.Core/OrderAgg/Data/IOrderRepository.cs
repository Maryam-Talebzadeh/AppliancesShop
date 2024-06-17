using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace SM.Domain.Core.OrderAgg.Data
{
   public  interface IOrderRepository
    {
        Task<long> PlaceOrder(OrderDTO order, CancellationToken cancellationToken);
        Task<double> GetAmountBy(long id, CancellationToken cancellationToken);
        Task Cancel(long id, CancellationToken cancellationToken);
        Task PaymentSucceeded(long orderId, long refId, string issueTrackingNo, CancellationToken cancellationToken);
        Task<List<OrderItemDTO>> GetItems(long orderId, CancellationToken cancellationToken);
        Task<List<OrderDTO>> Search(SearchOrderDTO searchModel, CancellationToken cancellationToken);
        Task AddItem(OrderItemDTO item, CancellationToken cancellationToken);
    }
}

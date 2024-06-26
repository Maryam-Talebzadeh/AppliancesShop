using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Entities;

namespace SM.Domain.Core.OrderAgg.Data
{
   public  interface IOrderRepository : IRepository<Order>
    {
        Task<long> PlaceOrder(OrderDTO order, CancellationToken cancellationToken);
        Task<double> GetAmountBy(long id, CancellationToken cancellationToken);
        Task Cancel(long id, CancellationToken cancellationToken);
        Task PaymentSucceeded(long orderId, long refId, string issueTrackingNo, CancellationToken cancellationToken);
        Task<List<OrderItemDTO>> GetItems(long orderId, CancellationToken cancellationToken);
        Task<List<OrderDTO>> Search(SearchOrderDTO searchModel, CancellationToken cancellationToken);
        Task AddItem(OrderItemDTO item, CancellationToken cancellationToken);
        Task<OrderDTO> GetBy(long id, CancellationToken cancellationToken);
    }
}

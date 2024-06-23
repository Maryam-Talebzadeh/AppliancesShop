using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace SM.Domain.Core._0_Services
{
    public interface ISiteInventoryAcl
    {
        Task<bool> ReduceFromInventory(List<OrderItemDTO>? items, CancellationToken cancellationToken);
    }
}

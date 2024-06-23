using IM.Domain.Core.InventoryAgg.AppServices;
using IM.Domain.Core.InventoryAgg.DTOs;
using SM.Domain.Core._0_Services;
using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace SiteManagement.Infrastructure.InventoryAcl
{
    public class SiteInventoryAcl : ISiteInventoryAcl
    {
        private readonly IInventoryAppService _inventoryAppService;

        public SiteInventoryAcl(IInventoryAppService inventoryAppService)
        {
            _inventoryAppService = inventoryAppService;
        }

        public async Task<bool> ReduceFromInventory(List<OrderItemDTO>? items, CancellationToken cancellationToken)
        {
            var command = items.Select(orderItem =>
                    new ReduceInventoryDTO(orderItem.ProductId, orderItem.Count, "خرید مشتری", orderItem.OrderId))
                .ToList();

            var res = await _inventoryAppService.Reduce(command, cancellationToken);

            return res.IsSuccedded;
        }

    }
}

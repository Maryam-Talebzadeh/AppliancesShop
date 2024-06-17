using Base_Framework.Domain.Core.Contracts;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Domain.Core.InventoryAgg.Entities;

namespace IM.Domain.Core.InventoryAgg.Data
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task Create(CreateInventoryDTO command, CancellationToken cancellationToken);
        Task Edit(EditInventoryDTO command, CancellationToken cancellationToken);
        Task Increase(IncreaseInventoryDTO command, CancellationToken cancellationToken);
        Task Reduce(ReduceInventoryDTO command, CancellationToken cancellationToken);
        Task<EditInventoryDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<InventoryDTO>> Search(SearchInventoryDTO searchModel, CancellationToken cancellationToken);
        Task<List<InventoryOperationDTO>> GetOperationLog(long inventoryId, CancellationToken cancellationToken);
        Task<StockStatusDTO> CheckStock(IsInStockDTO command, CancellationToken cancellationToken);
    }
}

using Base_Framework.Domain.Services;
using IM.Domain.Core.InventoryAgg.DTOs;

namespace IM.Domain.Core.InventoryAgg.AppServices
{
    public interface IInventoryAppService
    {
        Task<OperationResult> Create(CreateInventoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditInventoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Increase(IncreaseInventoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Reduce(ReduceInventoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Reduce(List<ReduceInventoryDTO> command, CancellationToken cancellationToken);
        Task<EditInventoryDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<InventoryDTO>> Search(SearchInventoryDTO searchModel, CancellationToken cancellationToken);
        Task<List<InventoryOperationDTO>> GetOperationLog(long inventoryId, CancellationToken cancellationToken);
        Task<StockStatusDTO> CheckStock(IsInStockDTO command, CancellationToken cancellationToken);
    }
}

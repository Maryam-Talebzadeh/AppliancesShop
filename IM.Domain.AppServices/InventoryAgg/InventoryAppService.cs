using Base_Framework.Domain.Services;
using IM.Domain.Core.InventoryAgg.AppServices;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Domain.Core.InventoryAgg.Services;

namespace IM.Domain.AppServices.InventoryAgg
{
    public class InventoryAppService : IInventoryAppService
    {
        private readonly IInventoryService _inventoryService;

        public InventoryAppService(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<StockStatusDTO> CheckStock(IsInStockDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryService.CheckStock(command, cancellationToken);  
        }

        public async Task<OperationResult> Create(CreateInventoryDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryService.Create(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditInventoryDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryService.Edit(command, cancellationToken);
        }

        public async Task<EditInventoryDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _inventoryService.GetDetails(id, cancellationToken);
        }

        public async Task<List<InventoryOperationDTO>> GetOperationLog(long inventoryId, CancellationToken cancellationToken)
        {
            return await _inventoryService.GetOperationLog(inventoryId, cancellationToken);
        }

        public async Task<OperationResult> Increase(IncreaseInventoryDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryService.Increase(command, cancellationToken);
        }

        public async Task<OperationResult>  Reduce(ReduceInventoryDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryService.Reduce(command, cancellationToken);
        }

        public async Task<OperationResult> Reduce(List<ReduceInventoryDTO> command, CancellationToken cancellationToken)
        {
            return await _inventoryService.Reduce(command, cancellationToken);
        }

        public async Task<List<InventoryDTO>> Search(SearchInventoryDTO searchModel, CancellationToken cancellationToken)
        {
            return await _inventoryService.Search(searchModel, cancellationToken);
        }
    }
}

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

        public global::Base_Framework.Domain.Services.OperationResult Create(CreateInventoryDTO command)
        {
            return _inventoryService.Create(command);
        }

        public global::Base_Framework.Domain.Services.OperationResult Edit(EditInventoryDTO command)
        {
            return _inventoryService.Edit(command);
        }

        public EditInventoryDTO GetDetails(long id)
        {
            return _inventoryService.GetDetails(id);
        }

        public List<InventoryOperationDTO> GetOperationLog(long inventoryId)
        {
            return _inventoryService.GetOperationLog(inventoryId);
        }

        public global::Base_Framework.Domain.Services.OperationResult Increase(IncreaseInventoryDTO command)
        {
            return _inventoryService.Increase(command);
        }

        public global::Base_Framework.Domain.Services.OperationResult Reduce(ReduceInventoryDTO command)
        {
            return _inventoryService.Reduce(command);
        }

        public global::Base_Framework.Domain.Services.OperationResult Reduce(List<ReduceInventoryDTO> command)
        {
            return _inventoryService.Reduce(command);
        }

        public List<InventoryDTO> Search(SearchInventoryDTO searchModel)
        {
            return _inventoryService.Search(searchModel);
        }
    }
}

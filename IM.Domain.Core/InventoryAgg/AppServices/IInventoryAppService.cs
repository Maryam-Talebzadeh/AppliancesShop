using Base_Framework.Domain.Services;
using IM.Domain.Core.InventoryAgg.DTOs;

namespace IM.Domain.Core.InventoryAgg.AppServices
{
    public interface IInventoryAppService
    {
        OperationResult Create(CreateInventoryDTO command);
        OperationResult Edit(EditInventoryDTO command);
        OperationResult Increase(IncreaseInventoryDTO command);
        OperationResult Reduce(ReduceInventoryDTO command);
        OperationResult Reduce(List<ReduceInventoryDTO> command);
        EditInventoryDTO GetDetails(long id);
        List<InventoryDTO> Search(SearchInventoryDTO searchModel);
        List<InventoryOperationDTO> GetOperationLog(long inventoryId);
    }
}

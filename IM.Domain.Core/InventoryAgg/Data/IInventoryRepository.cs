using IM.Domain.Core.InventoryAgg.DTOs;

namespace IM.Domain.Core.InventoryAgg.Data
{
    public interface IInventoryRepository
    {
        void Create(CreateInventoryDTO command);
        void Edit(EditInventoryDTO command);
        void Increase(IncreaseInventoryDTO command);
        void Reduce(ReduceInventoryDTO command);
        void Reduce(List<ReduceInventoryDTO> command);
        EditInventoryDTO GetDetails(long id);
        List<InventoryDTO> Search(SearchInventoryDTO searchModel);
    }
}

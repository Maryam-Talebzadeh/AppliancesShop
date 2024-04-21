using Base_Framework.Domain.Core.Contracts;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Domain.Core.InventoryAgg.Entities;

namespace IM.Domain.Core.InventoryAgg.Data
{
    public interface IInventoryRepository : IRepository<Inventory>
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

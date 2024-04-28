using Base_Framework.Domain.Services;
using IM.Domain.Core.InventoryAgg.Data;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Domain.Core.InventoryAgg.Entities;
using IM.Domain.Core.InventoryAgg.Services;

namespace IM.Domain.Services.InventoryAgg
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventoryDTO command)
        {
            var operation = new OperationResult();

            if (_inventoryRepository.IsExist(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            _inventoryRepository.Create(command);
            _inventoryRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditInventoryDTO command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.IsExist(x => x.Id == command.Id);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_inventoryRepository.IsExist(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            _inventoryRepository.Edit(command);
            _inventoryRepository.Save();

            return operation.Succedded();
        }

        public EditInventoryDTO GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventoryDTO command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.IsExist(x => x.Id == command.InventoryId);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _inventoryRepository.Increase(command);
            _inventoryRepository.Save();

            return operation.Succedded();
        }
    

        public OperationResult Reduce(ReduceInventoryDTO command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.IsExist(x => x.Id == command.InventoryId);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            command.OrderId = 0;  //Because this operation is performed by storekeeper and not by the customer
            _inventoryRepository.Reduce(command);
            _inventoryRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Reduce(List<ReduceInventoryDTO> command)
        {
            var operation = new OperationResult();

            foreach (var item in command)
            {
                _inventoryRepository.Reduce(item);
            }

            _inventoryRepository.Save();
            return operation.Succedded();
        }

        public List<InventoryDTO> Search(SearchInventoryDTO searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
    }
}

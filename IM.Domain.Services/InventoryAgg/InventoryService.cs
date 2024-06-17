using Base_Framework.Domain.Services;
using IM.Domain.Core.InventoryAgg.Data;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Domain.Core.InventoryAgg.Services;
using System.Threading;

namespace IM.Domain.Services.InventoryAgg
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<StockStatusDTO> CheckStock(IsInStockDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.CheckStock(command,cancellationToken);
        }

        public async Task<OperationResult> Create(CreateInventoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_inventoryRepository.IsExist(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

           await _inventoryRepository.Create(command, cancellationToken);
           _inventoryRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditInventoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.IsExist(x => x.Id == command.Id);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_inventoryRepository.IsExist(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            await _inventoryRepository.Edit(command, cancellationToken);
            _inventoryRepository.Save();

            return operation.Succedded();
        }

        public async Task<EditInventoryDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.GetDetails(id, cancellationToken);
        }

        public async Task<List<InventoryOperationDTO>> GetOperationLog(long inventoryId, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.GetOperationLog(inventoryId, cancellationToken);
        }

        public async Task<OperationResult> Increase(IncreaseInventoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.IsExist(x => x.Id == command.InventoryId);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _inventoryRepository.Increase(command, cancellationToken);
            _inventoryRepository.Save();

            return operation.Succedded();
        }
    

        public async Task<OperationResult> Reduce(ReduceInventoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.IsExist(x => x.Id == command.InventoryId);

            if (inventory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            command.OrderId = 0;  //Because this operation is performed by storekeeper and not by the customer
            await _inventoryRepository.Reduce(command, cancellationToken);
            _inventoryRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Reduce(List<ReduceInventoryDTO> command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            foreach (var item in command)
            {
                await _inventoryRepository.Reduce(item, cancellationToken);
            }

            _inventoryRepository.Save();
            return operation.Succedded();
        }

        public async Task<List<InventoryDTO>> Search(SearchInventoryDTO searchModel, CancellationToken cancellationToken)
        {
            return await _inventoryRepository.Search(searchModel, cancellationToken);
        }
    }
    }


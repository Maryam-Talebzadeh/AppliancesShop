using Base_Framework.Domain.General;
using Base_Framework.Infrastructure.DataAccess;
using IM.Domain.Core.InventoryAgg.Data;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Domain.Core.InventoryAgg.Entities;
using IM.Infrastructure.DB.SqlServer.EFCore.contexts;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace IM.Infrastructure.DataAccess.Repos.EFCore.InventoryAgg
{
    public class InventoryRepository : BaseRepository_EFCore<Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public async Task Create(CreateInventoryDTO command, CancellationToken cancellationToken)
        {
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _context.Inventory.Add(inventory);

        }

        public async Task Edit(EditInventoryDTO command, CancellationToken cancellationToken)
        {
            var inventory = Get(command.Id);
            inventory.Edit(command.ProductId, command.UnitPrice);
        }

        public async Task<EditInventoryDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.Inventory.Select(i =>
            new EditInventoryDTO
            {
                Id = i.Id,
                ProductId = i.ProductId,
                UnitPrice = i.UnitPrice
            }).SingleOrDefault(i => i.Id == id);
        }

        public async Task<List<InventoryOperationDTO>> GetOperationLog(long inventoryId, CancellationToken cancellationToken)
        {
            var inventory = _context.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            var operations = inventory.Operations.Select(x => new InventoryOperationDTO
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OperatorId = x.OperatorId,
                Operator = "مدیر سیستم", // Temporary
                OrderId = x.OrderId
            }).OrderByDescending(x => x.Id).ToList();

            return operations;
        }

        public async Task Increase(IncreaseInventoryDTO command, CancellationToken cancellationToken)
        {
            var inventory = Get(command.InventoryId);
            var operatorId = 1; //Temporary
            inventory.Increase(command.Count, operatorId, command.Description);
        }

        public async Task Reduce(ReduceInventoryDTO command, CancellationToken cancellationToken)
        {
            var inventory = Get(command.InventoryId);
            var operatorId = 1; //Temporary
            inventory.Reduce(command.Count, operatorId, command.Description, command.OrderId);
        }

        public async Task<List<InventoryDTO>> Search(SearchInventoryDTO searchModel, CancellationToken cancellationToken)
        {
            var products = _shopContext.Products.Select(p => new { Id = p.Id, Name = p.Name });
            var query = _context.Inventory.Select(i =>
            new InventoryDTO
            {
                Id = i.Id,
                CreationDate = i.CreationDate.ToFarsi(),
                CurrentCount = i.CalculateCurrentCount(),
                InStock = i.InStock,
                ProductId = i.ProductId,
                UnitPrice = i.UnitPrice
            });

            if (searchModel.ProductId > 0)
                query = query.Where(i => i.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(i => !i.InStock);

            var inventory = query.OrderByDescending(i => i.Id).ToList();
            inventory.ForEach(inventory =>
            inventory.Product = products.SingleOrDefault(p => p.Id == inventory.ProductId)?.Name);

            return inventory;
        }
    }
}

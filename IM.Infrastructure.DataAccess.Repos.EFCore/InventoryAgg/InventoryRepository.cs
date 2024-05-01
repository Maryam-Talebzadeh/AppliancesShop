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

        public void Create(CreateInventoryDTO command)
        {
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _context.Inventory.Add(inventory);

        }

        public void Edit(EditInventoryDTO command)
        {
            var inventory = Get(command.Id);
            inventory.Edit(command.ProductId, command.UnitPrice);
        }

        public EditInventoryDTO GetDetails(long id)
        {
            return _context.Inventory.Select(i =>
            new EditInventoryDTO
            {
                Id = i.Id,
                ProductId = i.ProductId,
                UnitPrice = i.UnitPrice
            }).SingleOrDefault(i => i.Id == id);
        }

        public void Increase(IncreaseInventoryDTO command)
        {
            var inventory = Get(command.InventoryId);
            var operatorId = 1; //Temporary
            inventory.Increase(command.Count, operatorId, command.Description);
        }

        public void Reduce(ReduceInventoryDTO command)
        {
            var inventory = Get(command.InventoryId);
            var operatorId = 1; //Temporary
            inventory.Reduce(command.Count, operatorId, command.Description, command.OrderId);
        }

        public List<InventoryDTO> Search(SearchInventoryDTO searchModel)
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

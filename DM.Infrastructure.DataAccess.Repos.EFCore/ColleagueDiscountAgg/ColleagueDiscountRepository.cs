using Base_Framework.Domain.General;
using Base_Framework.Infrastructure.DataAccess;
using DM.Domain.Core.ColleagueDiscountAgg.Data;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Entities;
using DM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace DM.Infrastructure.DataAccess.Repos.EFCore.ColleagueDiscountAgg
{
    public class ColleagueDiscountRepository : BaseRepository_EFCore<ColleagueDiscount> , IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) :base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public async Task Create(DefineColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _context.ColleagueDiscounts.Add(colleagueDiscount);
        }

        public async Task Edit(EditColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            var colleagueDiscount = Get(command.Id);
            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
        }

        public async Task<EditColleagueDiscountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.ColleagueDiscounts.Select(cd =>
            new EditColleagueDiscountDTO()
            {
                Id = cd.Id,
                ProductId = cd.ProductId,
                DiscountRate = cd.DiscountRate,
            }).SingleOrDefault(cd => cd.Id == id);
        }

        public async Task Remove(long id, CancellationToken cancellationToken)
        {
            var colleagueDiscount = Get(id);
            colleagueDiscount.Remove();
        }

        public async Task Restore(long id, CancellationToken cancellationToken)
        {
            var colleagueDiscount = Get(id);
            colleagueDiscount.ReStore();
        }

        public async Task<List<ColleagueDiscountDTO>> Search(SearchColleagueDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            var products = _shopContext.Products.Select(p => new { Id = p.Id, Name = p.Name });
            var query = _context.ColleagueDiscounts.Select(cd =>
            new ColleagueDiscountDTO()
            {
                CreationDate = cd.CreationDate.ToFarsi(),
                DiscountRate = cd.DiscountRate,
                Id = cd.Id,
                IsRemoved = cd.IsRemoved,
                ProductId = cd.ProductId
            });

            if (searchModel.ProductId > 0)
                query = query.Where(cd => cd.ProductId == searchModel.ProductId);

            var discounts = query.OrderByDescending(cd => cd.ProductId == searchModel.ProductId).ToList();
            discounts.ForEach(discount =>
                discount.Product = products.FirstOrDefault(p => p.Id == discount.ProductId)?.Name);

            return discounts;
        }
    }
}

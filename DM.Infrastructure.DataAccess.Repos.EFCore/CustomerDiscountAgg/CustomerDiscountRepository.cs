using Base_Framework.Infrastructure.DataAccess;
using DM.Domain.Core.CustomerDiscountAgg.Data;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using DM.Domain.Core.CustomerDiscountAgg.Entities;
using DM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.Domain.General;

namespace DM.Infrastructure.DataAccess.Repos.EFCore.CustomerDiscountAgg
{
    public class CustomerDiscountRepository : BaseRepository_EFCore<CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) :base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public void Create(DefineCustomerDiscountDTO command)
        {
            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, command.StartDate.ToGregorianDateTime(), command.EndDate.ToGregorianDateTime(), command.Reason);
            _context.CustomerDiscounts.Add(customerDiscount);

        }

        public void Edit(EditCustoemrDiscountDTO command)
        {
            var customerDiscount = Get(command.Id);
            customerDiscount.Edit(command.ProductId, command.DiscountRate, command.StartDate.ToGregorianDateTime(), command.EndDate.ToGregorianDateTime(), command.Reason);
        }

        public EditCustoemrDiscountDTO GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(cd =>
            new EditCustoemrDiscountDTO()
            {
                Id = cd.Id,
                DiscountRate = cd.DiscountRate,
                EndDate = cd.EndDate.ToFarsi(),
                StartDate = cd.StartDate.ToFarsi(),
                ProductId = cd.ProductId,
                Reason = cd.Reason

            }).SingleOrDefault(cd => cd.Id == id);
        }

        public List<CustomerDiscountDTO> Search(SearchCustomerDiscountDTO searchModel)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();

            var query = _context.CustomerDiscounts.Select(cd =>
             new CustomerDiscountDTO()
             {
                 Id = cd.Id,
                 DiscountRate = cd.DiscountRate,
                 EndDate = cd.EndDate.ToFarsi(),
                 StartDate = cd.StartDate.ToFarsi(),
                 ProductId = cd.ProductId,
                 Reason = cd.Reason,
                 CreationDate = cd.CreationDate.ToFarsi(),
                 EndDateGr = cd.EndDate,
                 StartDateGr = cd.StartDate
             });

            if(searchModel.ProductId > 0)
            {
                query.Where(cd => cd.ProductId == searchModel.ProductId);
            }

            if(!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query = query.Where(cd => cd.StartDateGr < searchModel.StartDate.ToGregorianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                query = query.Where(cd => cd.EndDateGr < searchModel.EndDate.ToGregorianDateTime());
            }

            var discounts = query.OrderByDescending(cd => cd.Id).ToList();

            discounts.ForEach(discount =>
            discount.Product = products.FirstOrDefault(p => p.Id == discount.ProductId)?.Name);

            return discounts;
        }
    }
}

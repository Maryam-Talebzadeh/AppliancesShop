using Base_Framework.Domain.General;
using Base_Framework.Infrastructure.DataAccess;
using DM.Domain.Core.ColleagueDiscountAgg.Data;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Entities;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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

        public void Create(DefineColleagueDiscountDTO command)
        {
            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _context.ColleagueDiscounts.Add(colleagueDiscount);
        }

        public void Edit(EditColleagueDiscountDTO command)
        {
            var colleagueDiscount = Get(command.Id);
            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
        }

        public EditColleagueDiscountDTO GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(cd =>
            new EditColleagueDiscountDTO()
            {
                Id = cd.Id,
                ProductId = cd.ProductId,
                DiscountRate = cd.DiscountRate,
            }).SingleOrDefault(cd => cd.Id == id);
        }

        public void Remove(long id)
        {
            var colleagueDiscount = Get(id);
            colleagueDiscount.Remove();
        }

        public void Restore(long id)
        {
            var colleagueDiscount = Get(id);
            colleagueDiscount.ReStore();
        }

        public List<ColleagueDiscountDTO> Search(SearchColleagueDiscountDTO searchModel)
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

using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg
{
    public class ProductPictureRepository : BaseRepository_EFCore<long, Product> IProductPictureRepository
    {

        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateProductPictureDTO command)
        {
            var picture =new ProductPicture(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle)
        }

        public void Edit(EditProductPictureDTO command)
        {
            throw new NotImplementedException();
        }

        public EditProductPictureDTO GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Expression<Func<ProductPicture, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Restore(long id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<ProductPictureDTO> Search(SearchProductPictureDTO searchModel)
        {
            throw new NotImplementedException();
        }
    }
}

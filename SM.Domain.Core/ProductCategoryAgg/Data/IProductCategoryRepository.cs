using ServiceFramework;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using System.Linq.Expressions;

namespace SM.Domain.Core.ProductCategoryAgg.Data
{
    public interface IProductCategoryRepository
    {
        void Create(CreateProductCategoryDTO productCategory);
        ProductCategoryDTO GetBy(int id);
        void Save();
        bool IsExist(Expression<Func<ProductCategoryDTO, bool>> expression);

    }
}

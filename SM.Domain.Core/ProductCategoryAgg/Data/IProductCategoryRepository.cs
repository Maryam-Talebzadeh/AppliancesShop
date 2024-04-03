using ServiceFramework;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using System.Linq.Expressions;

namespace SM.Domain.Core.ProductCategoryAgg.Data
{
    public interface IProductCategoryRepository
    {
        void Create(CreateProductCategoryDTO productCategory);
        ProductCategoryDTO GetBy(long id);
        void Save();
        bool IsExist(Expression<Func<ProductCategory, bool>> expression);
        void Edit(EditProductCategoryDTO edit);
        ProductCategoryDetailDTO GetDetail(long id);
        List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel);
    }
}

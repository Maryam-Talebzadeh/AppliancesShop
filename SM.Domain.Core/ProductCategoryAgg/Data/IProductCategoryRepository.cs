using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using System.Linq.Expressions;

namespace SM.Domain.Core.ProductCategoryAgg.Data
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        void Create(CreateProductCategoryDTO productCategory);
        ProductCategoryDTO GetBy(long id);
        void Save();
        bool IsExist(Expression<Func<ProductCategory, bool>> expression);
        void Edit(EditProductCategoryDTO edit);
        ProductCategoryDetailDTO GetDetail(long id);
        List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel);
        List<ProductCategoryDTO> GetAll();
    }
}

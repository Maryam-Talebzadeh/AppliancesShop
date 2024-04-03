using ServiceFramework;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;

namespace SM.Domain.Core.ProductCategoryAgg.Data
{
    public interface IProductCategoryRepository
    {
        void Create(CreateProductCategoryDTO productCategory);
        ProductCategory GetBy(int id);
        void Save();

    }
}

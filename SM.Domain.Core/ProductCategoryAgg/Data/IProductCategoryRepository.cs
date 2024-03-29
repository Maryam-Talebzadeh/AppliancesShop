using SM.Domain.Core.ProductCategoryAgg.DTOs;

namespace SM.Domain.Core.ProductCategoryAgg.Data
{
    public interface IProductCategoryRepository
    {
        void Create(CreateProductCategoryDTO productCategory);
        ProductCategoryDTO GetBy(int id);
    }
}

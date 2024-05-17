using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductCategoryAgg.DTOs;

namespace SM.Domain.Core.ProductCategoryAgg.Services
{
    public interface IProductCategoryService
    {
        OperationResult Create(CreateProductCategoryViewModel command);
        OperationResult Edit(EditProductCategoryViewModel command);
        List<ProductCategoryViewModel> Search(SearchProductCategoryDTO searchModel);
        ProductCategoryDetailViewModel GetDetail(long id);
        List<ProductCategoryViewModel> GetAll();
    }
}

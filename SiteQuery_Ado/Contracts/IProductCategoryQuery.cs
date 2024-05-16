

using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }
}

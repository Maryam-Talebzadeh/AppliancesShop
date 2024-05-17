

using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug);
        ProductCategoryQueryModel GetProductCategoryBy(string slug);
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }
}



using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductCategoryQuery
    {
        Task<ProductCategoryQueryModel> GetProductCategoryWithProducstsBy(string slug, CancellationToken cancellationToken);
        Task<ProductCategoryQueryModel> GetProductCategoryBy(string slug, CancellationToken cancellationToken);
        Task<List<ProductCategoryQueryModel>> GetProductCategories(CancellationToken cancellationToken);
        Task<List<ProductCategoryQueryModel>> GetProductCategoriesWithProducts(CancellationToken cancellationToken);
    }
}

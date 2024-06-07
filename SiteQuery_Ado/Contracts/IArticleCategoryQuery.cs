using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IArticleCategoryQuery
    {
        Task<ArticleCategoryQueryModel> GetArticleCategory(string slug, CancellationToken cancellationToken);
        Task<List<ArticleCategoryQueryModel>> GetArticleCategories(CancellationToken cancellationToken);
    }
}

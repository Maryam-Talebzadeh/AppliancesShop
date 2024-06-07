using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IArticleQuery
    {
        Task<List<ArticleQueryModel>> LatestArticles(CancellationToken cancellationToken);
        Task<ArticleQueryModel> GetArticleDetails(string slug, CancellationToken cancellationToken);
    }
}

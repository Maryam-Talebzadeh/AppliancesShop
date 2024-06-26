

namespace SiteQuery_EfCore.Contracts
{
    public interface IChartQuery
    {
        Task<List<string>> GetAllProductNames(CancellationToken cancellationToken);
        Task<List<int>> GetArticleCounts(CancellationToken cancellationToken);
        Task<List<string>> GetAllArticleCategoryName(CancellationToken cancellationToken);
        Task<List<int>> GetNumberOfRegisteredAccountsByMonth(CancellationToken cancellationToken);
        Task<int> GetNumberOfRegisteredAccounts(CancellationToken cancellationToken);
        Task<int> GetNumberOfProducts(CancellationToken cancellationToken);
        Task<int> GetNumberOfArticles(CancellationToken cancellationToken);
    }
}

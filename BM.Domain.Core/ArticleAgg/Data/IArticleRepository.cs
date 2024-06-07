using Base_Framework.Domain.Core.Contracts;
using BM.Domain.Core.ArticleAgg.Entities;
using BM.Domain.Core.ArticleAgg.DTOs;

namespace BM.Domain.Core.ArticleAgg.Data
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task Create(CreateArticleDTO command, CancellationToken cancellationToken);
        Task Edit(EditArticleDTO command, CancellationToken cancellationToken);
        Task<List<ArticleDTO>> Search(SearchArticleDTO searchModel, CancellationToken cancellationToken);
        Task<EditArticleDTO> GetDetails(long id, CancellationToken cancellationToken);
    }
}

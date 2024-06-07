using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleAgg.DTOs;

namespace BM.Domain.Core.ArticleAgg.Services
{
    public interface IArticleService
    {
        Task<OperationResult> Create(CreateArticleDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditArticleDTO command, CancellationToken cancellationToken);
        Task<EditArticleDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ArticleDTO>> Search(SearchArticleDTO searchModel, CancellationToken cancellationToken);
    }
}

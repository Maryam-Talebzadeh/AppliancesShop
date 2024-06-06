using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleCategoryAgg.DTOs;

namespace BM.Domain.Core.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryService
    {
        Task<OperationResult> Create(CreateArticleCategoryDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditArticleCategoryDTO command, CancellationToken cancellationToken);
        Task<EditArticleCategoryDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ArticleCategoryDTO>> GetArticleCategories (CancellationToken cancellationToken);
        Task<List<ArticleCategoryDTO>> Search(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken);
    }
}

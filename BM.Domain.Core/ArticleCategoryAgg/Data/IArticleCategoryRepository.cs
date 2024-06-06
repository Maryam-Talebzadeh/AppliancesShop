using BM.Domain.Core.ArticleCategoryAgg.DTOs;

namespace BM.Domain.Core.ArticleCategoryAgg.Data
{
    public interface IArticleCategoryRepository
    {
        Task Create(CreateArticleCategoryDTO command, CancellationToken cancellationToken);
        Task Edit(EditArticleCategoryDTO command, CancellationToken cancellationToken);
        Task<List<ArticleCategoryDTO>> Search(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken);
        Task<EditArticleCategoryDTO> GetDetails(long id,  CancellationToken cancellationToken);
    }
}

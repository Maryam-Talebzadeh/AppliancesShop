using Base_Framework.Domain.Core.Contracts;
using BM.Domain.Core.ArticleCategoryAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.Entities;

namespace BM.Domain.Core.ArticleCategoryAgg.Data
{
    public interface IArticleCategoryRepository : IRepository<ArticleCategory>
    {
        Task Create(CreateArticleCategoryDTO command, CancellationToken cancellationToken);
        Task Edit(EditArticleCategoryDTO command, CancellationToken cancellationToken);
        Task<List<ArticleCategoryDTO>> Search(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken);
        Task<EditArticleCategoryDTO> GetDetails(long id,  CancellationToken cancellationToken);
    }
}

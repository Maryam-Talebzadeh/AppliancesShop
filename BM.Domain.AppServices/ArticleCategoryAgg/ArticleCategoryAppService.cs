using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleCategoryAgg.AppServices;
using BM.Domain.Core.ArticleCategoryAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BM.Domain.AppServices.ArticleCategoryAgg
{
    public class ArticleCategoryAppService : IArticleCategoryAppService
    {
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoryAppService(IArticleCategoryService articleCategoryService)
        {
            _articleCategoryService = articleCategoryService;
        }

        public async Task<OperationResult> Create(CreateArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            return await _articleCategoryService.Create(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            return await _articleCategoryService.Edit(command, cancellationToken);
        }

        public async Task<List<ArticleCategoryDTO>> GetArticleCategories(CancellationToken cancellationToken)
        {
            return await _articleCategoryService.GetArticleCategories(cancellationToken);
        }

        public async Task<EditArticleCategoryDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _articleCategoryService.GetDetails(id, cancellationToken);
        }

        public async Task<List<ArticleCategoryDTO>> Search(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            return await _articleCategoryService.Search(searchModel, cancellationToken);
        }
    }
}

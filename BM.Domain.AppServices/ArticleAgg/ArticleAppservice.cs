using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleAgg.AppServices;
using BM.Domain.Core.ArticleAgg.DTOs;
using BM.Domain.Core.ArticleAgg.Services;

namespace BM.Domain.AppServices.ArticleAgg
{
    public class ArticleAppservice : IArticleAppService
    {
        private readonly IArticleService _articleService;

        public ArticleAppservice(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<OperationResult> Create(CreateArticleDTO command, CancellationToken cancellationToken)
        {
            return await _articleService.Create(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditArticleDTO command, CancellationToken cancellationToken)
        {
            return await _articleService.Edit(command, cancellationToken);
        }

        public async Task<EditArticleDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _articleService.GetDetails(id, cancellationToken);
        }

        public async Task<List<ArticleDTO>> Search(SearchArticleDTO searchModel, CancellationToken cancellationToken)
        {
            return await _articleService.Search(searchModel, cancellationToken);
        }
    }
}

using BM.Domain.Core.ArticleAgg.AppServices;
using BM.Domain.Core.ArticleAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Blog.ArticleAgg
{
    public class IndexModel : PageModel
    {
        public SearchArticleDTO SearchModel;
        public List<ArticleDTO> Articles;
        public SelectList ArticleCategories;

        private readonly IArticleAppService _articleAppService;
        private readonly IArticleCategoryAppService _articleCategoryAppService;

        public IndexModel(IArticleAppService articleAppService, IArticleCategoryAppService articleCategoryAppService)
        {
            _articleAppService = articleAppService;
            _articleCategoryAppService = articleCategoryAppService;
        }

        public async Task OnGet(SearchArticleDTO searchModel, CancellationToken cancellationToken)
        {
            ArticleCategories = new SelectList(await _articleCategoryAppService.GetArticleCategories(cancellationToken), "Id", "Name");
            Articles = await _articleAppService.Search(searchModel, cancellationToken);
        }
    }
}

using BM.Domain.Core.ArticleCategoryAgg.AppServices;
using BM.Domain.Core.ArticleCategoryAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Blog.ArticleCategoryAgg
{
    public class IndexModel : PageModel
    {
        public SearchArticleCategoryDTO SearchModel;
        public List<ArticleCategoryDTO> ArticleCategories;

        private readonly IArticleCategoryAppService _articleCategoryAppService;

        public IndexModel(IArticleCategoryAppService articleCategoryAppService)
        {
            _articleCategoryAppService = articleCategoryAppService;
        }

        public async Task OnGet(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            ArticleCategories = await _articleCategoryAppService.Search(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            return Partial("./Create", new CreateArticleCategoryDTO());
        }

        public async Task<JsonResult> OnPostCreate(CreateArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _articleCategoryAppService.Create(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var productCategory = await _articleCategoryAppService.GetDetails(id, cancellationToken);
            return Partial("Edit", productCategory);
        }

        public async Task<JsonResult> OnPostEdit(EditArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _articleCategoryAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }
    }
}

using BM.Domain.Core.ArticleAgg.AppServices;
using BM.Domain.Core.ArticleAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Blog.ArticleAgg
{
    public class EditModel : PageModel
    {
        public EditArticleDTO Command;
        public SelectList ArticleCategories;

        private readonly IArticleAppService _articleAppService;
        private readonly IArticleCategoryAppService _articleCategoryAppService;

        public EditModel(IArticleAppService articleAppService, IArticleCategoryAppService articleCategoryAppService)
        {
            _articleAppService = articleAppService;
            _articleCategoryAppService = articleCategoryAppService;
        }

        public async Task OnGet(long id, CancellationToken cancellationToken)
        {
            Command =await _articleAppService.GetDetails(id, cancellationToken);
            ArticleCategories = new SelectList(await _articleCategoryAppService.GetArticleCategories(cancellationToken), "Id", "Name");
        }

        public async Task<IActionResult> OnPost(EditArticleDTO command, CancellationToken cancellationToken)
        {
            var result =await _articleAppService.Edit(command, cancellationToken);
            return RedirectToPage("./Index");
        }
    }
}

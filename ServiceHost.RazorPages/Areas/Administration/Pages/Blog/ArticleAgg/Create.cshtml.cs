using BM.Domain.Core.ArticleAgg.AppServices;
using BM.Domain.Core.ArticleAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Blog.ArticleAgg
{
    public class CreateModel : PageModel
    {
        public CreateArticleDTO Command;
        public SelectList ArticleCategories;

        private readonly IArticleAppService _articleAppService;
        private readonly IArticleCategoryAppService _articleCategoryAppService;

        public CreateModel(IArticleAppService articleAppService, IArticleCategoryAppService articleCategoryAppService)
        {
            _articleAppService = articleAppService;
            _articleCategoryAppService = articleCategoryAppService;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            ArticleCategories = new SelectList(await _articleCategoryAppService.GetArticleCategories(cancellationToken), "Id", "Name");
        }

        public async Task<IActionResult> OnPost(CreateArticleDTO command, CancellationToken cancellationToken)
        {
            var result = await _articleAppService.Create(command, cancellationToken);
            return RedirectToPage("./Index");
        }
    }
}

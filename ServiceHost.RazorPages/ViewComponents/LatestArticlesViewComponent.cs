using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class LatestArticlesViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var articles = await _articleQuery.LatestArticles(cancellationToken);
            return View(articles);
        }
    }
}

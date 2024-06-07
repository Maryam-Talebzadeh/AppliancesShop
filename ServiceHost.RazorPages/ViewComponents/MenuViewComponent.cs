using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _productCategoryQuery = productCategoryQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result = new MenuModel
            {
                ArticleCategories =await _articleCategoryQuery.GetArticleCategories(cancellationToken),
                ProductCategories =await _productCategoryQuery.GetProductCategories(cancellationToken)
            };
            return View(result);
        }
    }
}

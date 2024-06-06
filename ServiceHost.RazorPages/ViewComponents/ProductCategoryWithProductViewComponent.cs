using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class ProductCategoryWithProductViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync( CancellationToken cancellationToken)
        {
            var categories = await _productCategoryQuery.GetProductCategoriesWithProducts( cancellationToken);
            return View(categories);
        }
    }
}

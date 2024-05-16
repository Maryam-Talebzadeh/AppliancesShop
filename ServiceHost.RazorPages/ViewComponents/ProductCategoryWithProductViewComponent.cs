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

        public IViewComponentResult Invoke()
        {
            var categories = _productCategoryQuery.GetProductCategoriesWithProducts();
            return View(categories);
        }
    }
}

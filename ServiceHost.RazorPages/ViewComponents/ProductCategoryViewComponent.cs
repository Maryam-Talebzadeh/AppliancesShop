using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;
using SM.Domain.Core.ProductCategoryAgg.AppServices;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync( CancellationToken cancellationToken)
        {
            var productCategories =await  _productCategoryQuery.GetProductCategories(cancellationToken);
            return View(productCategories);
        }
    }
}

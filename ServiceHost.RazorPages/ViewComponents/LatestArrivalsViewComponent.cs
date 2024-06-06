using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;

namespace ServiceHost.RazorPages.ViewComponents
{
        public class LatestArrivalsViewComponent : ViewComponent
        {
            private readonly IProductQuery _productQuery;

            public LatestArrivalsViewComponent(IProductQuery productQuery)
            {
                _productQuery = productQuery;
            }

            public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
            {
                var products =await _productQuery.GetLatestArrivals(cancellationToken);
                return View(products);
            }
        }
    
}

using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class LatestArrivals
    {
        public class LatestArrivalsViewComponent : ViewComponent
        {
            private readonly IProductQuery _productQuery;

            public LatestArrivalsViewComponent(IProductQuery productQuery)
            {
                _productQuery = productQuery;
            }

            public IViewComponentResult Invoke()
            {
                var products = _productQuery.GetLatestArrivals();
                return View(products);
            }
        }
    }
}

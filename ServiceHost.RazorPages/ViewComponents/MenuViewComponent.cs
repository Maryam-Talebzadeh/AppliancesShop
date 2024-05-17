using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public MenuViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}

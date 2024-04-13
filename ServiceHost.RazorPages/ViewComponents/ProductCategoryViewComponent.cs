using Microsoft.AspNetCore.Mvc;
using SM.Domain.Core.ProductCategoryAgg.AppServices;

namespace ServiceHost.RazorPages.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryAppService _productCategoryAppService;

        public ProductCategoryViewComponent(IProductCategoryAppService productCategoryAppService)
        {
            _productCategoryAppService = productCategoryAppService;
        }

        public IViewComponentResult Invoke()
        {
            var productCategories = _productCategoryAppService.GetAll();
            return View(productCategories);
        }
    }
}

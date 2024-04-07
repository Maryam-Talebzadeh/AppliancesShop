using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.Domain.Core.ProductCategoryAgg.AppServices;
using SM.Domain.Core.ProductCategoryAgg.DTOs;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryAppService _productCategoryAppService;
        public List<ProductCategoryViewModel> ProductCategories;

        public IndexModel(IProductCategoryAppService productCategoryAppService)
        {
            _productCategoryAppService = productCategoryAppService;
        }

        public void OnGet(SearchProductCategoryDTO search)
        {
            ProductCategories = _productCategoryAppService.Search(search);
        }
    }
}

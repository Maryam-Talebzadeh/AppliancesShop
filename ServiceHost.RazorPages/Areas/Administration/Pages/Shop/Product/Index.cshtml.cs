using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.AppServices.ProductAgg;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.AppServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly IProductCategoryAppService _productCategoryAppService;

        public List<ProductDTO> Products;
        public SearchProductDTO SearchModel;
        public SelectList ProductCategories;

        public IndexModel(ProductAppService productAppService, IProductCategoryAppService productCategoryAppService)
        {
            _productAppService = productAppService;
            _productCategoryAppService = productCategoryAppService;
        }

        public void OnGet(SearchProductDTO search)
        {
            ProductCategories = new SelectList(_productCategoryAppService.GetAll(), "Id", "Name");
            Products = _productAppService.Search(search);
        }

        public ActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductDTO());
        }

        public JsonResult OnPostCreate(CreateProductDTO command)
        {
            var result = _productAppService.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productAppService.GetDetails(id);

            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProductDTO  command)
        {
            var result = _productAppService.Edit(command);
            return new JsonResult(result);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductCategoryAgg.AppServices;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.ProductAgg.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly IProductCategoryAppService _productCategoryAppService;

        public List<ProductDTO> Products;
        public SearchProductDTO SearchModel;
        public SelectList ProductCategories;

        [TempData]
        public string Message { get; set; }

        public IndexModel(IProductAppService productAppService, IProductCategoryAppService productCategoryAppService)
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
            var command = new CreateProductDTO();
            command.Categories = _productCategoryAppService.GetAll();

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductDTO command)
        {
            var result = _productAppService.Create(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productAppService.GetDetails(id);
            product.Categories = _productCategoryAppService.GetAll();

            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProductDTO command)
        {
            var result = _productAppService.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetNotInStock(long id)
        {
            var result = _productAppService.NotInStock(id);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetIsInStock(long id)
        {
            var result = _productAppService.IsInStock(id);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

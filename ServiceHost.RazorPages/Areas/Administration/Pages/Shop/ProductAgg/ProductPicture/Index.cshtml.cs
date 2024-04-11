using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.ProductAgg.ProductPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchProductPictureDTO SearchModel;
        public List<ProductPictureDTO> ProductPictures;
        public SelectList Products;

        private readonly IProductAppService _productAppService;
        private readonly IProductPictureAppService _productPictureAppService;
        public IndexModel(IProductPictureAppService productPictureAppService, IProductAppService productApplication)
        {
            _productAppService = productApplication;
            _productPictureAppService = productPictureAppService;
        }

        public void OnGet(int id, SearchProductPictureDTO? searchModel)
        {
            Products = new SelectList(_productAppService.GetProducts(), "Id", "Name");
            ProductPictures = _productPictureAppService.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPictureViewModel
            {
                Products = _productAppService.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPictureViewModel command)
        {
            var result = _productPictureAppService.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureAppService.GetDetails(id);
            productPicture.Products = _productAppService.GetProducts();
            return Partial("Edit", productPicture);
        }

        public JsonResult OnPostEdit(EditProductPictureViewModel command)
        {
            var result = _productPictureAppService.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureAppService.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureAppService.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

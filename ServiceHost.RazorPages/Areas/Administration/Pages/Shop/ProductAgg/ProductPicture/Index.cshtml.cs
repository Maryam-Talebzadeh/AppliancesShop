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

        public async Task OnGet(int id, SearchProductPictureDTO? searchModel, CancellationToken cancellationToken)
        {
            Products = new SelectList(await _productAppService.GetProducts(cancellationToken), "Id", "Name");
            ProductPictures = await _productPictureAppService.Search(searchModel , cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            var command = new CreateProductPictureViewModel
            {
                Products = await _productAppService.GetProducts(cancellationToken)
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(CreateProductPictureViewModel command, CancellationToken cancellationToken)
        {
            var result = await _productPictureAppService.Create(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var productPicture = await _productPictureAppService.GetDetails(id, cancellationToken);
            productPicture.Products = await _productAppService.GetProducts(cancellationToken);
            return Partial("Edit", productPicture);
        }

        public async Task<JsonResult> OnPostEdit(EditProductPictureViewModel command, CancellationToken cancellationToken)
        {
            var result = await _productPictureAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetRemove(long id, CancellationToken cancellationToken)
        {
            var result = await _productPictureAppService.Remove(id, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetRestore(long id, CancellationToken cancellationToken)
        {
            var result = await _productPictureAppService.Restore(id, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

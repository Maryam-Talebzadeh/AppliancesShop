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

        public async Task OnGet(SearchProductDTO search, CancellationToken cancellationToken)
        {
            ProductCategories = new SelectList(_productCategoryAppService.GetAll(), "Id", "Name");
            Products = await _productAppService.Search(search, cancellationToken);
        }

        public async Task<ActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            var command = new CreateProductDTO();
            command.Categories = _productCategoryAppService.GetAll();

            return Partial("./Create", command);
        }

        public async Task<ActionResult> OnPostCreate(CreateProductDTO command, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return Partial("./Create", command);
            }

            var result = await _productAppService.Create(command, cancellationToken);

            return new JsonResult(result);
        }

        public async Task<ActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var product = await _productAppService.GetDetails(id, cancellationToken);
            product.Categories = _productCategoryAppService.GetAll();

            return Partial("Edit", product);
        }

        public async Task<ActionResult> OnPostEdit(EditProductDTO command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Partial("Edit", command);
            }

            var result = await _productAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<ActionResult> OnGetNotInStock(long id, CancellationToken cancellationToken)
        {
            var result = await _productAppService.NotInStock(id, cancellationToken);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public async Task<ActionResult> OnGetIsInStock(long id, CancellationToken cancellationToken)
        {
            var result = await _productAppService.IsInStock(id, cancellationToken);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

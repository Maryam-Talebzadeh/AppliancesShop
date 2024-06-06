using DM.Domain.Core.ColleagueDiscountAgg.AppServices;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Discounts.ColleagueDiscountAgg
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchColleagueDiscountDTO SearchModel;
        public List<ColleagueDiscountDTO> ColleagueDiscounts;
        public SelectList Products;

        private readonly IProductAppService _productAppService;
        private readonly IColleagueDiscountAppService _colleagueDiscountAppService;

        public IndexModel(IProductAppService productAppService, IColleagueDiscountAppService colleagueDiscountAppService)
        {
            _productAppService = productAppService;
            _colleagueDiscountAppService = colleagueDiscountAppService;
        }

        public async Task OnGet(SearchColleagueDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            Products = new SelectList(await _productAppService.GetProducts(cancellationToken), "Id", "Name");
            ColleagueDiscounts = await _colleagueDiscountAppService.Search(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate( CancellationToken cancellationToken)
        {
            var command = new DefineColleagueDiscountDTO
            {
                Products = await _productAppService.GetProducts( cancellationToken)
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(DefineColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            var result = await _colleagueDiscountAppService.Define(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var colleagueDiscount = await _colleagueDiscountAppService.GetDetails(id, cancellationToken);
            colleagueDiscount.Products = await _productAppService.GetProducts( cancellationToken);
            return Partial("Edit", colleagueDiscount);
        }

        public async Task<JsonResult> OnPostEdit(EditColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            var result = await _colleagueDiscountAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetRemove(long id, CancellationToken cancellationToken)
        {
            await _colleagueDiscountAppService.Remove(id, cancellationToken);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetRestore(long id, CancellationToken cancellationToken)
        {
            await _colleagueDiscountAppService.Restore(id, cancellationToken);
            return RedirectToPage("./Index");
        }

    }
}

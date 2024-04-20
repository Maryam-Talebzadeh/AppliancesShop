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

        public void OnGet(SearchColleagueDiscountDTO searchModel)
        {
            Products = new SelectList(_productAppService.GetProducts(), "Id", "Name");
            ColleagueDiscounts = _colleagueDiscountAppService.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscountDTO
            {
                Products = _productAppService.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscountDTO command)
        {
            var result = _colleagueDiscountAppService.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var colleagueDiscount = _colleagueDiscountAppService.GetDetails(id);
            colleagueDiscount.Products = _productAppService.GetProducts();
            return Partial("Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscountDTO command)
        {
            var result = _colleagueDiscountAppService.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _colleagueDiscountAppService.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _colleagueDiscountAppService.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}

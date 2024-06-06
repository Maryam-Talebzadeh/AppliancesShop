using DM.Domain.AppServices.CustomerDiscountAgg;
using DM.Domain.Core.CustomerDiscountAgg.AppSevices;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;
using System.Threading;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Discounts.CustomerDiscountAgg
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchCustomerDiscountDTO SearchModel;
        public List<CustomerDiscountDTO> CustomerDiscounts;
        public SelectList Products;

        private readonly IProductAppService _productAppService;
        private readonly ICustomerDiscountAppService _customerDiscountAppService;

        public IndexModel(IProductAppService productAppService, ICustomerDiscountAppService customerDiscountApplication)
        {
            _productAppService = productAppService;
            _customerDiscountAppService = customerDiscountApplication;
        }

        public async Task OnGet(SearchCustomerDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            Products = new SelectList(await _productAppService.GetProducts( cancellationToken), "Id", "Name");
            CustomerDiscounts = await _customerDiscountAppService.Search(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            var command = new DefineCustomerDiscountDTO
            {
                Products = await _productAppService.GetProducts( cancellationToken)
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(DefineCustomerDiscountDTO command, CancellationToken cancellationToken)
        {
            var result = await _customerDiscountAppService.Define(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var customerDiscount = await _customerDiscountAppService.GetDetails(id, cancellationToken);
            customerDiscount.Products = await  _productAppService.GetProducts(cancellationToken);
            return Partial("Edit", customerDiscount);
        }

        public async Task<JsonResult> OnPostEdit(EditCustomerDiscountDTO command, CancellationToken cancellationToken)
        {
            var result = _customerDiscountAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }
    }
}

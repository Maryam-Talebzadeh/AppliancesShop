using DM.Domain.AppServices.CustomerDiscountAgg;
using DM.Domain.Core.CustomerDiscountAgg.AppSevices;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;

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

        public IndexModel(IProductAppService productAppService, CustomerDiscountAppService customerDiscountApplication)
        {
            _productAppService = productAppService;
            _customerDiscountAppService = customerDiscountApplication;
        }

        public void OnGet(SearchCustomerDiscountDTO searchModel)
        {
            Products = new SelectList(_productAppService.GetProducts(), "Id", "Name");
            CustomerDiscounts = _customerDiscountAppService.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscountDTO
            {
                Products = _productAppService.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscountDTO command)
        {
            var result = _customerDiscountAppService.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var customerDiscount = _customerDiscountAppService.GetDetails(id);
            customerDiscount.Products = _productAppService.GetProducts();
            return Partial("Edit", customerDiscount);
        }

        public JsonResult OnPostEdit(EditCustoemrDiscountDTO command)
        {
            var result = _customerDiscountAppService.Edit(command);
            return new JsonResult(result);
        }
    }
}

using AM.Domain.Core.AccountAgg.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.OrderAgg.AppServices;
using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.OrderAgg
{
    public class IndexModel : PageModel
    {
        public SearchOrderDTO SearchModel;
        public SelectList Accounts;
        public List<OrderDTO> Orders;

        private readonly IOrderAppService _orderAppService;
        private readonly IAccountAppService _accountAppService;

        public IndexModel(IOrderAppService orderAppService, IAccountAppService accountAppService)
        {
            _orderAppService = orderAppService;
            _accountAppService = accountAppService;
        }

        public async Task OnGet(SearchOrderDTO searchModel, CancellationToken cancellationToken)
        {
            Accounts = new SelectList(await _accountAppService.GetAccounts(cancellationToken), "Id", "Fullname");
            Orders = await _orderAppService.Search(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetConfirm(long id,  CancellationToken cancellationToken)
        {
           await _orderAppService.PaymentSucceeded(id, 0, cancellationToken);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetCancel(long id, CancellationToken cancellationToken)
        {
           await _orderAppService.Cancel(id, cancellationToken);
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetItems(long id, CancellationToken cancellationToken)
        {
            var items = await _orderAppService.GetItems(id, cancellationToken);
            return Partial("Items", items);
        }
    }
}

using AM.Domain.Core.AccountAgg.AppServices;
using AM.Domain.Core.AccountAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Account.AccountAgg
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SearchAccountDTO SearchModel;
        public List<AccountDTO> Accounts;

        private readonly IAccountAppService _accountAppService;

        public IndexModel(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public async Task OnGet(SearchAccountDTO searchModel, CancellationToken cancellationToken)
        {
            Accounts =await _accountAppService.Search(searchModel,cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate( CancellationToken cancellationToken)
        {
            var command = new RegisterAccountDTO
            {
               
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(RegisterAccountDTO command, CancellationToken cancellationToken)
        {
            command.RoleId = 1; //Temporary
            var result =await _accountAppService.Register(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var account =await _accountAppService.GetDetails(id, cancellationToken);
            return Partial("Edit", account);
        }

        public async Task<JsonResult> OnPostEdit(EditAccountDTO command, CancellationToken cancellationToken)
        {
            command.RoleId = 1; //Temporary
            var result = await _accountAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetChangePassword(long id, CancellationToken cancellationToken)
        {
            var command = new ChangePasswordDTO { Id = id };
            return Partial("ChangePassword", command);
        }

        public async Task<JsonResult> OnPostChangePassword(ChangePasswordDTO command, CancellationToken cancellationToken)
        {
            var result =await _accountAppService.ChangePassword(command, cancellationToken);
            return new JsonResult(result);
        }
    }
}

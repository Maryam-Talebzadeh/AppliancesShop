using AM.Domain.Core.AccountAgg.AppServices;
using AM.Domain.Core.AccountAgg.DTOs;
using AM.Domain.Core.RoleAgg.AppServices;
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
        public SelectList Roles;

        private readonly IAccountAppService _accountAppService;
        private readonly IRoleAppService _roleAppService;

        public IndexModel(IAccountAppService accountAppService, IRoleAppService roleAppService)
        {
            _accountAppService = accountAppService;
            _roleAppService = roleAppService;
        }

        public async Task OnGet(SearchAccountDTO searchModel, CancellationToken cancellationToken)
        {
            Roles = new SelectList(await _roleAppService.GetAll(cancellationToken), "Id", "Name");
            Accounts =await _accountAppService.Search(searchModel,cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate( CancellationToken cancellationToken)
        {
            var command = new RegisterAccountDTO
            {
               Roles = await _roleAppService.GetAll(cancellationToken)
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(RegisterAccountDTO command, CancellationToken cancellationToken)
        {
            var result =await _accountAppService.Register(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var account =await _accountAppService.GetDetails(id, cancellationToken);
            account.Roles = await _roleAppService.GetAll(cancellationToken);
            return Partial("Edit", account);
        }

        public async Task<JsonResult> OnPostEdit(EditAccountDTO command, CancellationToken cancellationToken)
        {
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

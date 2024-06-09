using AM.Domain.Core.RoleAgg.AppServices;
using AM.Domain.Core.RoleAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Account.RoleAgg
{
    public class EditModel : PageModel
    {
        public EditRoleDTO Command;
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleAppService _roleAppService;

        public EditModel(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task OnGet(long id, CancellationToken cancellationToken)
        {
            Command = await _roleAppService.GetDetails(id, cancellationToken);

        }

        public async Task<IActionResult> OnPost(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var result = await _roleAppService.Edit(command, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}

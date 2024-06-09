using AM.Domain.Core.RoleAgg.AppServices;
using AM.Domain.Core.RoleAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Account.RoleAgg
{
    public class CreateModel : PageModel
    {
        public CreateRoleDTO Command;
        private readonly IRoleAppService _roleAppService;

        public CreateModel(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }



        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var result = await _roleAppService.Create(command, cancellationToken);
            return RedirectToPage("Index");
        }

    }
}

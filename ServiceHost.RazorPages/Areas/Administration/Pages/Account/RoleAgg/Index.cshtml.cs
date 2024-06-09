using AM.Domain.Core.RoleAgg.AppServices;
using AM.Domain.Core.RoleAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Account.RoleAgg
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<RoleDTO> Roles;

        private readonly IRoleAppService _roleAppService;

        public IndexModel(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Roles = await _roleAppService.GetAll(cancellationToken);
        }
    }
}

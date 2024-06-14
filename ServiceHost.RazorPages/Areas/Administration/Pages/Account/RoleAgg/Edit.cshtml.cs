using AM.Domain.Core.RoleAgg.AppServices;
using AM.Domain.Core.RoleAgg.DTOs;
using Base_Framework.Domain.Core.Contracts;
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
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public EditModel(IRoleAppService roleAppService, IEnumerable<IPermissionExposer> exposers)
        {
            _roleAppService = roleAppService;
            _exposers = exposers;
        }

        public async Task OnGet(long id, CancellationToken cancellationToken)
        {
            Command = await _roleAppService.GetDetails(id, cancellationToken);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    var group = new SelectListGroup { Name = key };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }
        }
        public async Task<IActionResult> OnPost(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var result = await _roleAppService.Edit(command, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}

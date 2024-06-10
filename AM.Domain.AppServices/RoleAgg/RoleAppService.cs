using AM.Domain.Core.RoleAgg.AppServices;
using AM.Domain.Core.RoleAgg.DTOs;
using AM.Domain.Core.RoleAgg.Services;
using Base_Framework.Domain.Services;

namespace AM.Domain.AppServices.RoleAgg
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleService _roleService;

        public RoleAppService(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            return await _roleService.Create(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken)
        {
            return await _roleService.Edit(command, cancellationToken);
        }

        public async Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _roleService.GetAll(cancellationToken);
        }

        public async Task<EditRoleDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _roleService.GetDetails(id, cancellationToken);
        }
    }
}

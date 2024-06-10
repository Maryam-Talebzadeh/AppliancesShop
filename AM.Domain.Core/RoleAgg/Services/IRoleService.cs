using AM.Domain.Core.RoleAgg.DTOs;
using Base_Framework.Domain.Services;

namespace AM.Domain.Core.RoleAgg.Services
{
    public interface IRoleService
    {
        Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken);
        Task<EditRoleDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken);
    }
}

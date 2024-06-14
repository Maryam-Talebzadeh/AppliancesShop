using AM.Domain.Core.RoleAgg.DTOs;
using AM.Domain.Core.RoleAgg.Entities;
using Base_Framework.Domain.Core.Contracts;

namespace AM.Domain.Core.RoleAgg.Data
{
   public interface IRoleRepository : IRepository<Role>
    {
        Task Create(CreateRoleDTO command, CancellationToken cancellationToken);
        Task Edit(EditRoleDTO command, CancellationToken cancellationToken);
        Task<EditRoleDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken);
        Task<List<int>> GetPermissionsCodeBy(long roleId,  CancellationToken cancellationToken);
    }
}

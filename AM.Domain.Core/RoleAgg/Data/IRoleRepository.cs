using AM.Domain.Core.RoleAgg.DTOs;

namespace AM.Domain.Core.RoleAgg.Data
{
   public interface IRoleRepository
    {
        Task Create(CreateRoleDTO command, CancellationToken cancellationToken);
        Task Edit(EditRoleDTO command, CancellationToken cancellationToken);
        Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken);
    }
}

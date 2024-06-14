

using Base_Framework.Domain.Core.Contracts;

namespace AM.Domain.Core.RoleAgg.DTOs
{
   public class EditRoleDTO : CreateRoleDTO
    {
        public long Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }

        public EditRoleDTO()
        {
            Permissions = new List<int>();
        }
    }
}

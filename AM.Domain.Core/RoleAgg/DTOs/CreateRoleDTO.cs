

namespace AM.Domain.Core.RoleAgg.DTOs
{
    public class CreateRoleDTO
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }
}

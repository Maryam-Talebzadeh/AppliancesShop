using AM.Domain.Core.AccountAgg.Entities;
using Base_Framework.Domain.Core.Entities;

namespace AM.Domain.Core.RoleAgg.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public List<Permission> Permissions { get; private set; }
        public List<Account> Accounts { get; private set; }

        protected Role()
        {
        }

        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            Accounts = new List<Account>();
        }

        public void Edit(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}

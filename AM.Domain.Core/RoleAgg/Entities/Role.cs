using AM.Domain.Core.AccountAgg.Entities;
using Base_Framework.Domain.Core.Entities;

namespace AM.Domain.Core.RoleAgg.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }

        protected Role()
        {
        }

        public Role(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}

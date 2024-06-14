

namespace AM.Domain.Core.RoleAgg.Entities
{
    public class Permission
    {
        public long Id { get;  set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public long RoleId { get;  set; }
        public Role Role { get; private set; }

        public Permission(int code)
        {
            Code = code;
        }

        public Permission(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}

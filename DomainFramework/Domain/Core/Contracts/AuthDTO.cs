namespace Base_Framework.Domain.Core.Contracts
{
    public class AuthDTO
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }

        public AuthDTO()
        {
        }

        public AuthDTO(long id, long roleId, string fullname, string username, string mobile
           )
        {
            Id = id;
            RoleId = roleId;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
        }
    }
}

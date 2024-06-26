﻿using AM.Domain.Core.RoleAgg.Entities;
using Base_Framework.Domain.Core.Entities;

namespace AM.Domain.Core.AccountAgg.Entities
{
    public class Account : BaseEntity
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string? Mobile { get; private set; }
        public long RoleId { get; private set; }
        public string? ProfilePhoto { get; private set; }
        public Role Role { get; set; }

        public Account(string fullname, string username, string password, string mobile,
            long roleId, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;

            if (roleId == 0)
                RoleId = 2;

            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullname, string username, string mobile,
            long roleId, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}

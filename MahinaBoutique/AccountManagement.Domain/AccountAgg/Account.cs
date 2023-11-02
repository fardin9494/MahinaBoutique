using _0_SelfBuildFramwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }

        public string UserName { get; set; }

        public int RoleId { get; private set; }

        public string Mobile { get; private set; }

        public string Password { get; private set; }

        public string ProfilePhoto { get; private set; }

        public Account(string fullName, string userName, int roleId, string mobile, string password, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            RoleId = roleId;
            Mobile = mobile;
            Password = password;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullName, string userName, int roleId, string mobile, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            RoleId = roleId;
            Mobile = mobile;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
            {
                ProfilePhoto = profilePhoto;
            }
            
        }

        public void ChangePasword(string newPassword)
        {
            Password = newPassword;
        }
    }
}

using System.Collections.Generic;

namespace _0_SelfBuildFramwork.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public long RoleId { get; set; }

        public List<int> Permissions { get; set; }

        public AuthViewModel(long id, string fullName, string userName, long roleId, List<int> permissions)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            RoleId = roleId;
            Permissions = permissions;
        }
    }
}
namespace _0_SelfBuildFramwork.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public long RoleId { get; set; }

        public AuthViewModel(long id, string fullName, string userName, long roleId)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            RoleId = roleId;
        }
    }
}
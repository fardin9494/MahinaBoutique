namespace AccountManagement.Application.Contract.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public int RoleId { get; set; }

        public string Role { get; set; }

        public string Mobile { get; set; }

        public string ProfilePhoto { get; set; }
    }
}

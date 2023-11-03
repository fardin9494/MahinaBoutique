using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccount
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public long RoleId { get; set; }

        public string Mobile { get; set; }

        public string Password { get; set; }

        public IFormFile ProfilePhoto { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}

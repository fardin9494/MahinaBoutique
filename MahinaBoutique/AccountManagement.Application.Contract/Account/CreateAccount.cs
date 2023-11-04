using _0_SelfBuildFramwork.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccount
    {
        [Required (ErrorMessage =ValidationMessages.Required)]
        public string FullName { get; set; }

        [Required (ErrorMessage =ValidationMessages.Required)]
        public string UserName { get; set; }

        [Range(1,10 ,ErrorMessage =ValidationMessages.Required)]
        public long RoleId { get; set; }

        [Required (ErrorMessage =ValidationMessages.Required)]
        public string Mobile { get; set; }

        [Required (ErrorMessage =ValidationMessages.Required)]
        public string Password { get; set; }

        public string RePassword { get; set; }

        public IFormFile ProfilePhoto { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}

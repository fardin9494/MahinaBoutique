using _0_SelfBuildFramwork.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contract.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string UserName { get; set; }
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password { get; set; }
    }
}
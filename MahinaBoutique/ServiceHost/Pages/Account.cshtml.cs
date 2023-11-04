using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string loginMessage { get; set; }

        [TempData]
        public string registerMessage { get; set; }
        
        [TempData]
        public bool registerMessageClass { get; set; }

        public LoginModel Command { get; set; }

        public CreateAccount CreateCommand { get; set; }
        

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPostSignIn(LoginModel command)
        {
           var result = _accountApplication.Login(command);
            if (!result.IsSuccedded)
            {
                loginMessage = result.Message;
                return RedirectToPage("/Account");
            }
            else
            {
                return RedirectToPage("/index");
            }  
        }

        public RedirectToPageResult OnGetLogOut()
        {
            _accountApplication.LogOut();
            return RedirectToPage("/index");
        }

        public RedirectToPageResult OnPostRegister(CreateAccount createcommand)
        {
            createcommand.RoleId = 2;

            if(createcommand.Password != createcommand.RePassword)
            {
                registerMessage = "پسوورد تطابق ندارد";
                return RedirectToPage("/Account");
            }

            var result = _accountApplication.Create(createcommand);

            
            if (result.IsSuccedded)
            {
                registerMessageClass = true;
                registerMessage = result.Message;
                return RedirectToPage("/Account");
                
            }
            else
            {
                registerMessage = result.Message;
                return RedirectToPage("/Account");
            }
        }
    }
}

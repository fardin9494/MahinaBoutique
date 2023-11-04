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
        public string Message { get; set; }

        public LoginModel Command { get; set; }

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
                Message = result.Message;
                return RedirectToPage("/Account");
            }
            else
            {
                return RedirectToPage("/index");
            }  
        }

        public RedirectToPageResult OnGetSignOut()
        {
            _accountApplication.LogOut();
            return RedirectToPage("/index");
        }
    }
}

using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
    public class CreateModel : PageModel
    {
        public CreateRole Command { get; set; }
       
        private readonly IRoleApplication _roleApplication;

        public CreateModel(IRoleApplication roleApplication)
        { 
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
         
        }

        public RedirectToPageResult  OnPost(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}

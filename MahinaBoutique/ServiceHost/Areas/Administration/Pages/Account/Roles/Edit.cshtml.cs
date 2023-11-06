using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
    public class EditModel : PageModel
    {
        public EditRole Command{ get; set; }

        private readonly IRoleApplication _roleApplication;

        public EditModel(IRoleApplication roleApplication)
        { 
            _roleApplication = roleApplication;
        }

        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditRole command)
        {
           _roleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}

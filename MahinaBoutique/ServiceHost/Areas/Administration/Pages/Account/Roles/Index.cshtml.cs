using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
    public class IndexModel : PageModel
    {
        public List<RoleViewModel> Roles { get; set; }

        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        { 
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles= _roleApplication.GetRoles();
        }

        public IActionResult OnGetCreate()
        {
            var createRole = new CreateRole();
            
            return Partial("./Create",createRole);
        }

        public JsonResult OnPostCreate(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var SelectedItem = _roleApplication.GetDetails(id);
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}

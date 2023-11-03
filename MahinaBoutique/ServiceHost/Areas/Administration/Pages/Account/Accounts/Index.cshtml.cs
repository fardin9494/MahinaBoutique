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

namespace ServiceHost.Areas.Administration.Pages.Account.Accounts
{
    public class IndexModel : PageModel
    {
       
        public AccountSearchModel SearchModel { get; set; }

        public SelectList Roles;

        public List<AccountViewModel> Accounts { get; set; }

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.GetRoles(),"Id","Name");
            Accounts= _accountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var createAccount = new CreateAccount()
            {
                Roles = _roleApplication.GetRoles()
            };
            return Partial("./Create",createAccount);
        }

        public JsonResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var SelectedItem = _accountApplication.GetDetails(id);
            SelectedItem.Roles = _roleApplication.GetRoles();
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var selectedItem = new ChangeAccountPassword{Id = id};
            return Partial("./ChangePassword",selectedItem);
        }

        public JsonResult OnPostChangePassword(ChangeAccountPassword command)
        {
            var result = _accountApplication.ChangePassword(command);
            return new JsonResult(result);
        }
    }
}

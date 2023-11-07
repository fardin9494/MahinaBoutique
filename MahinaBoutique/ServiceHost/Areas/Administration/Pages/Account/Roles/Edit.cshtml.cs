using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
    public class EditModel : PageModel
    {
        public List<SelectListItem> Permission;

        public EditRole Command{ get; set; }

        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
             Permission = new List<SelectListItem>();
        }

        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach(var expose in _exposers)
            {
                var permissions = expose.Expose();
                foreach(var permission in permissions)
                {
                    var gruop = new SelectListGroup
                    {
                        Name = permission.Key
                    };

                    foreach(var permissiondio in permission.Value)
                    {
                        var item = (new SelectListItem(permissiondio.Name,$"{permissiondio.Name},{permissiondio.Code}")
                        {
                           Group = gruop,
                        });
                        Permission.Add(item);
                        
                        foreach(var selectedPermission in Command.PermissionDto)
                        {
                            if(item.Text == selectedPermission.Name)
                            {
                                 item.Selected = true;
                            }
                        }
                    }

                }
            }
        }

        public RedirectToPageResult OnPost(EditRole command)
        {
           _roleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}

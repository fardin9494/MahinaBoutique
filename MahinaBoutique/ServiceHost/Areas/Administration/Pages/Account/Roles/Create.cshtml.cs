using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> Permission;

        public CreateRole Command { get; set; }
       
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public CreateModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
            Permission = new List<SelectListItem>();
        }

        public void OnGet()
        {
            
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
                        Permission.Add(new SelectListItem(permissiondio.Name,$"{permissiondio.Name},{permissiondio.Code}")
                        {
                           Group = gruop,
                        });
                    }

                }
            }
        }

        public RedirectToPageResult  OnPost(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}

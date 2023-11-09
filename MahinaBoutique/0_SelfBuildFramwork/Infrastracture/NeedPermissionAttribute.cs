using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_SelfBuildFramwork.Infrastracture
{
    public class NeedPermissionAttribute : Attribute
    {
        public int PermissionCode{get; set; }

        public NeedPermissionAttribute(int permissionCode)
        {
            PermissionCode = permissionCode;
        }
    }
}

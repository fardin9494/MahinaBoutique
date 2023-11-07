using _0_SelfBuildFramwork.Infrastracture;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Role
{
    public class EditRole : CreateRole
    {
        public List<PermissionDto> PermissionDto { get; set; }

        public long Id { get; set; }
    }
}

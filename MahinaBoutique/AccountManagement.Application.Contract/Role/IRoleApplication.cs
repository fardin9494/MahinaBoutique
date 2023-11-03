using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);

        OperationResult Edit(EditRole command);

        EditRole GetDetails(long Id);

        List<RoleViewModel> GetRoles();
    }
}

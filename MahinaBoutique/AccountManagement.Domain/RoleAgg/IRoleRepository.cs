using _0_SelfBuildFramwork.Domain;
using AccountManagement.Application.Contract.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long,Role>
    {
        EditRole GetDetails(long Id);

        List<RoleViewModel> GetRoles();
    }
}

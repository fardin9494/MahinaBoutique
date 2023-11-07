using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastracture.EfCore.Repositories
{
    public class RoleRepository : BaseRepository<long, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;
        }

        public EditRole GetDetails(long Id)
        {
            return _accountContext.Roles.Include(x => x.Permissions).Select(x => new EditRole{ 
                Id = x.Id,
                Name = x.Name,
                PermissionDto = MapPermission(x.Permissions)
                }).AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        private static List<PermissionDto> MapPermission(List<RolePermission> permissions)
        {
           return permissions.Select(x => new PermissionDto(x.Code,x.Name)).ToList();
                
        }

        public List<RoleViewModel> GetRoles()
        {
             return _accountContext.Roles.Select(x => new RoleViewModel{ 
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                }).ToList();
        }
    }
}

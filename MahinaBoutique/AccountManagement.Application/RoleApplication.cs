using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if(_roleRepository.IsExist(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            var permisions = new List<RolePermission>();
            
            if(command.Permissions != null)
            {
                foreach(var StringPermission in command.Permissions)
                {
                int PermissionCode = int.Parse(StringPermission.Split(",")[1]);
                string PermissionName = StringPermission.Split(",")[0];
                permisions.Add(new RolePermission(PermissionCode,PermissionName));
                }      
            }

            var Role = new Role(command.Name,permisions);
            
            _roleRepository.Create(Role);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var SelectedRole = _roleRepository.GetBy(command.Id);
            if(SelectedRole == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            if(_roleRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var permisions = new List<RolePermission>();
            
            if(command.Permissions != null)
            {
                foreach(var StringPermission in command.Permissions)
                {
                int PermissionCode = int.Parse(StringPermission.Split(",")[1]);
                string PermissionName = StringPermission.Split(",")[0];
                permisions.Add(new RolePermission(PermissionCode,PermissionName));
                } 
            }     

            SelectedRole.Edit(command.Name,permisions);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditRole GetDetails(long Id)
        {
            return _roleRepository.GetDetails(Id);
        }

        public List<RoleViewModel> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
    }
}

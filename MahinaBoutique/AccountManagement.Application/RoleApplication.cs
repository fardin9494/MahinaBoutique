using _0_SelfBuildFramwork.Application;
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
            this._roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if(_roleRepository.IsExist(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var Role = new Role(command.Name);
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
            SelectedRole.Edit(command.Name);
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

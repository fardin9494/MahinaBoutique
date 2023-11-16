using _0_SelfBuildFramwork.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _repository;
        private readonly IAuthHelper _authHelper;

        public InventoryApplication(IInventoryRepository repository, IAuthHelper authHelper)
        {
            _repository = repository;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operation = new OperationResult();
            if(_repository.IsExist(x => x.ProductId == command.ProductId))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            
            var inventory = new Inventory(command.ProductId,command.UnitPrice);
            _repository.Create(inventory);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();
            var selectedInventory = _repository.GetBy(command.Id);
            if(selectedInventory == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            if(_repository.IsExist(x => x.ProductId == selectedInventory.ProductId && x.Id != selectedInventory.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }

            selectedInventory.Edit(command.ProductId,command.UnitPrice);
            _repository.SaveChanges();
            return operation.Succedded();
            
        }

        public EditInventory GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation = new OperationResult();
            var operatorid = _authHelper.AuthenticatedAccountId();
            var inventory = _repository.GetBy(command.InventoryId);
            inventory.Increase(command.Count,operatorid,command.Description);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public List<InventoryOperationViewModel> Operations(long InventoryId)
        {
             return  _repository.Operations(InventoryId);
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operation = new OperationResult();
            var operatorid = _authHelper.AuthenticatedAccountId();
            var inventory = _repository.GetWith(command.InventoryId);
            inventory.Reduce(command.Count,operatorid,command.Description,0);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
           var operation = new OperationResult();
            var operatorid = _authHelper.AuthenticatedAccountId();
            foreach(var item in command)
            {
                var inventory = _repository.GetWith(item.ProductId);
                inventory.Reduce(item.Count,operatorid,item.Description,item.OrderId);
            }

            _repository.SaveChanges();
            return operation.Succedded();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}

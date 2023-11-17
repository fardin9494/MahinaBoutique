using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Infrastracture.EfCore;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastracture.EfCore.Repositories
{
    public class InventoryRepository : BaseRepository<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext, AccountContext accountContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public bool CheckInventoryStatus(long ProductId , int count)
        {
           var inventory =  _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == ProductId);
           return inventory.CalculateCurrentCount() - count >= 0;
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory{ 
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                }).FirstOrDefault(x => x.Id == id);
        }

        public Inventory GetWith(long ProductId)
        {
           return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public List<InventoryOperationViewModel> Operations(long InventoryId)
        {
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == InventoryId);
            var account = _accountContext.Accounts.Select(x => new{x.Id,x.FullName}).ToList();

           var opertions = inventory.Operations.Select(x => new InventoryOperationViewModel{
               Count = x.Count,
               CurrentCount = x.CurrentCount,
               Description = x.Description,
               Id = x.Id,
               Operation = x.Operation,
               OperationTime = x.OperationTime.ToFarsi(),
               OperatorId = x.OperatorId,
               OrderId = x.OrderId,
               }).ToList();

            foreach(var operation in opertions)
            {
                operation.Operator = account.FirstOrDefault(x => x.Id == operation.OperatorId)?.FullName;
            }

            return opertions;
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var product = _shopContext.Products.Select(x => new{x.Id,x.Name}).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                InStock = x.InStock,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CreaionDate = x.CreationDate.ToFarsi(),
                CurrentCount = x.CalculateCurrentCount()
            });

            if (searchModel.ProductId != 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            if (searchModel.InStock)
            {
                query = query.Where(x => !x.InStock);
            }

            var Inventory = query.OrderByDescending(x => x.Id).ToList();
            
            Inventory.ForEach(inven => inven.Product = product.FirstOrDefault(x => x.Id == inven.ProductId)?.Name);

            return Inventory;
        }
    }
}

using InventoryManagement.Application.Contract.Inventory;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;
using System;
using System.Collections.Generic;

namespace ShopManagement.Infrastracture.InventoryAcl
{
    public class ShopInventoryAcl : IShopInventoryAcl
    {
        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool CheckItemInStock(long ProductId, int count)
        {
            return _inventoryApplication.CheckItemInStock(ProductId,count);
        }

        public bool ReduceInventory(List<Orderitem> items)
        {
            var reduces = new List<ReduceInventory>();
            foreach(var item in items)
            {
                var reduce = new ReduceInventory(item.ProductId,item.OrderId,"خرید از سایت",item.Count);
                reduces.Add(reduce);
            }

           return _inventoryApplication.Reduce(reduces).IsSuccedded;

        }
    }
}

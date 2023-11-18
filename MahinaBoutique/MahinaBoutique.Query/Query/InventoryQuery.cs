using InventoryManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Inventory;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class InventoryQuery : IInventoryQuery
    {
        private readonly InventoryContext _inventoryContext;
        
        private readonly ShopContext _shopContext;

        public InventoryQuery(InventoryContext inventoryContext, ShopContext shopContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public StockStatus CheckInventoryStatus(IsInStock command)
        {
            
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == command.ProductId);
            if(inventory == null || inventory.CalculateCurrentCount() < command.Count)
            {
                var Product = _shopContext.Products.Select(x => new {x.Id,x.Name }).FirstOrDefault(x => x.Id == command.ProductId);
                return new StockStatus{
                    InStock = false,
                    Product = Product?.Name,
                    };
            }
            else
            {
                return new StockStatus
                {
                    InStock = true
                };
            }
        }
    }
}

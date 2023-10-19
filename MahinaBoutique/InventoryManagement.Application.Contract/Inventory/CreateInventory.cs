using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get; set; }

        public double UnitPrice{get; set;}

        public List<ProductViewModel> Products { get; set; }
    }
}

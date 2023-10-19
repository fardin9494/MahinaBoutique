using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(0,1000000,ErrorMessage=ValidationMessages.Required) ]
        public long ProductId { get; set; }

        [Range(0,double.MaxValue,ErrorMessage=ValidationMessages.Required) ]
        public double UnitPrice{get; set;}

        public List<ProductViewModel> Products { get; set; }
    }
}

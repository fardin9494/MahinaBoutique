using System.Collections.Generic;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {

        public InventorySearchModel SearchModel { get; set; }

        public SelectList Product;

        public List<InventoryViewModel> Invnetory { get; set; }

        private readonly IProductApplication _products;
        private readonly IInventoryApplication _inventoryApplication;

        public IndexModel(IProductApplication products, IInventoryApplication inventory)
        {
            _products = products;
            _inventoryApplication = inventory;

        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Product = new SelectList(_products.GetProducts(), "Id", "Name");
            Invnetory = _inventoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var CreateInventory = new CreateInventory()
            {
                Products = _products.GetProducts()
            };
            return Partial("./Create", CreateInventory);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _inventoryApplication.GetDetails(id);
            SelectedItem.Products = _products.GetProducts();
            return Partial("./Edit", SelectedItem);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            
            var Increase = new IncreaseInventory{
                InventoryId = id
                };
            _inventoryApplication.Increase(Increase);
            return Partial("./Increase",Increase);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var reduce = new ReduceInventory
            {
                InventoryId = id
            };
            return Partial("./Reduce",reduce);
        }

        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }

    }
}

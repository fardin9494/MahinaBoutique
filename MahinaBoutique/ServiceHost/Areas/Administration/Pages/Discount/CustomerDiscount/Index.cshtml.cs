using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
       
        public CustomerDiscountSearchModel SearchModel { get; set; }

        public SelectList Product;

        public List<CustomerDiscountViewModel> CustomerDiscount { get; set; }

        private readonly IProductApplication _products;
        private readonly ICustomerDiscountApplication _discount;

        public IndexModel(IProductApplication products,ICustomerDiscountApplication discount)
        {
            _products = products;
            _discount = discount;
            
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Product = new SelectList(_products.GetProducts(),"Id","Name");
            CustomerDiscount= _discount.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        { 
            var CreateCusDis = new DefineCustomerDiscount()
            {
                Products = _products.GetProducts()
            };
            return Partial("./Create",CreateCusDis);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _discount.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _discount.GetDetails(id);
            SelectedItem.Products = _products.GetProducts();
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _discount.Edit(command);
            return new JsonResult(result);
        }

     
    }
}

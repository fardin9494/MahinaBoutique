using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {

        public ColleagueDiscountSearchModel SearchModel { get; set; }

        public SelectList Product;

        public List<ColleagueDiscountViewModel> ColleagueDiscount { get; set; }

        private readonly IProductApplication _products;
        private readonly IColleagueDiscountApplication _discount;

        public IndexModel(IProductApplication products, IColleagueDiscountApplication discount)
        {
            _products = products;
            _discount = discount;

        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Product = new SelectList(_products.GetProducts(), "Id", "Name");
            ColleagueDiscount = _discount.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var CreateCusDis = new DefineColleagueDiscount()
            {
                Products = _products.GetProducts()
            };
            return Partial("./Create", CreateCusDis);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _discount.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _discount.GetDetails(id);
            SelectedItem.Products = _products.GetProducts();
            return Partial("./Edit", SelectedItem);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _discount.Edit(command);
            return new JsonResult(result);
        }

        public RedirectToPageResult OnGetActive(long id)
        {
            _discount.Active(id);
            return RedirectToPage("./Index");
        }

         public RedirectToPageResult OnGetDeactive(long id)
        {
            _discount.Deactive(id);
            return RedirectToPage("./Index");
        }

    }
}

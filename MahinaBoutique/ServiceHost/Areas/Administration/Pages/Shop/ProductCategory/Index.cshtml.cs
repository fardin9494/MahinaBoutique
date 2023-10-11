using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
       
        public ProductCategorySearchModel SearchModel { get; set; }

        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        private readonly IProductCategoryApplication _productCategory;

        public IndexModel(IProductCategoryApplication productCategory)
        {
            _productCategory = productCategory;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategory.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreatePoductCategory());
        }

        public JsonResult OnPostCreate(CreatePoductCategory command)
        {
            var result = _productCategory.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _productCategory.GetDetails(id);
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategory.Edit(command);
            return new JsonResult(result);
        }
    }
}

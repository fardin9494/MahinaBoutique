using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Infrastracture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagment.Infrastracture.Config.Permissions;

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

        [NeedPermission(ShopPermissions.ListProductCategory)]
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategory.Search(searchModel);
        }

        
        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreatePoductCategory());
        }

        [NeedPermission(ShopPermissions.CreateProduct)]
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

        [NeedPermission(ShopPermissions.EditProduct)]
        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (!ModelState.IsValid)
            {

            }
            var result = _productCategory.Edit(command);
            return new JsonResult(result);
        }
    }
}

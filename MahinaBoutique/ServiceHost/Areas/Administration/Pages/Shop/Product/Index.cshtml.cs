using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
       
        public ProductSearchModel SearchModel { get; set; }

        public SelectList ProductCategories;

        public List<ProductViewModel> Products { get; set; }

        private readonly IProductApplication _products;
        private readonly IProductCategoryApplication _productCategory;

        public IndexModel(IProductApplication products, IProductCategoryApplication productCategory)
        {
            _products = products;
            _productCategory = productCategory;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategory.GetList(),"Id","Name");
            Products= _products.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        { 
            var createProduct = new CreateProduct()
            {
                Categories = _productCategory.GetList()
            };
            return Partial("./Create",createProduct);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _products.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _products.GetDetails(id);
            SelectedItem.Categories = _productCategory.GetList();
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _products.Edit(command);
            return new JsonResult(result);
        }
    }
}

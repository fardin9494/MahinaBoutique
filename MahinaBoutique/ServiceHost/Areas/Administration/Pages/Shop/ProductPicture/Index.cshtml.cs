using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
       
        public ProductPictureSearchModel SearchModel { get; set; }

        public SelectList Products;

        public List<ProductPictureViewModel> ProductPictures { get; set; }

        private readonly IProductApplication _products;
        private readonly IProductPictureApplication _productPicture;

        public IndexModel(IProductApplication products, IProductPictureApplication productPicture)
        {
            _products = products;
            _productPicture = productPicture;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_products.GetProducts(),"Id","Name");
            ProductPictures =  _productPicture.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        { 
            var createProductPicture = new CreateProductPicture()
            {
                Products = _products.GetProducts()
            };
            return Partial("./Create",createProductPicture);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPicture.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _productPicture.GetDetails(id);
            SelectedItem.Products = _products.GetProducts();
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPicture.Edit(command);
            return new JsonResult(result);
        }

        public RedirectToPageResult OnGetRemove(long id)
        {
            var result = _productPicture.Remove(id);
            return RedirectToPage("./Index");
            //we can control server erorr here with result
        }

        public RedirectToPageResult OnGetRestore(long id)
        {
            var result= _productPicture.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}

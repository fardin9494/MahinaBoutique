using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product { get; set; }
        
        private readonly IProductQuery _productQuery;

        public ProductModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetDeatail(id);
        }
    }
}

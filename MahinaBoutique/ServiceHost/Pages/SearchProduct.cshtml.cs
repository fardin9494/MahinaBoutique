using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchProductModel : PageModel
    {
        public string Value;
        public List<ProductQueryModel> Products { get; set; }
        private readonly IProductQuery _productQuery;

        public SearchProductModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string value)
        {
            Value = value;
            Products = _productQuery.Search(value);
        }
    }
}

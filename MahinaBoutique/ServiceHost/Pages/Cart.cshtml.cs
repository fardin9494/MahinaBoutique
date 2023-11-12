using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using Newtonsoft.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }
        public const string CookieName = "Item-cart";
        private readonly IProductQuery _productQuery;

        public CartModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            var Serialaizer = new JavaScriptSerializer();
            var Value = Request.Cookies[CookieName];
            var Carts = Serialaizer.Deserialize<List<CartItem>>(Value);
            foreach(var Cart in Carts)
            {
                var NumberPrice = double.Parse(Cart.UnitPrice, CultureInfo.CreateSpecificCulture("fa-ir"));
                Cart.ItemPrice = NumberPrice * Cart.ProductCount;
            }

            CartItems = _productQuery.CheckInventoryStatus(Carts);
        }

        public RedirectToPageResult OnGetRemoveCart(long id)
        {
            
            var serializer = new JavaScriptSerializer();
            var Value = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var CartList = serializer.Deserialize<List<CartItem>>(Value);
            var ItemToRemove = CartList.FirstOrDefault(x => x.Id == id);
            CartList.Remove(ItemToRemove);
            var option = new CookieOptions {Expires = DateTime.Now.AddDays(2) , IsEssential = true , Path = "/"};
            Response.Cookies.Append(CookieName, JsonConvert.SerializeObject(CartList) ,option);
            return RedirectToPage("/Cart");

        }

        public RedirectToPageResult OnGetGoToCheckOut()
        {
            var Serialaizer = new JavaScriptSerializer();
            var Value = Request.Cookies[CookieName];
            var Carts = Serialaizer.Deserialize<List<CartItem>>(Value);
            Carts = _productQuery.CheckInventoryStatus(Carts);
            
            if(Carts.Any(x => !x.IsInStock))
            {
              return  RedirectToPage("./Cart");
            }
            else
            {
              return  RedirectToPage("/CheckOut");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MahinaBoutique.Query.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public Cart Carts { get; set; }
        public const string CookieName = "Item-cart";
       
        private readonly ICartCalculator _cartCalculator;

        public CheckOutModel(ICartCalculator cartCalculator)
        {
            _cartCalculator = cartCalculator;
        }

        public void OnGet()
        {
            var Serialaizer = new JavaScriptSerializer();
            var Value = Request.Cookies[CookieName];
            var ListCartItem = Serialaizer.Deserialize<List<CartItem>>(Value);
            foreach(var Cart in ListCartItem)
            {
                var NumberPrice = double.Parse(Cart.UnitPrice, CultureInfo.CreateSpecificCulture("fa-ir"));
                Cart.ItemPrice = NumberPrice * Cart.ProductCount;
            }

            Carts = _cartCalculator.CalculateCart(ListCartItem);
        }
    }
}

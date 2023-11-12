using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class Cart
    {
        public double TotalPriceAmount { get; set; }

        public double TotalDiscountAmount { get; set; }

        public double TotalPayAmount { get; set; }

        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }


        public void Add(CartItem cartItem)
        {
            Items.Add(cartItem);
            
            TotalPriceAmount += cartItem.ItemPrice;

            TotalDiscountAmount += cartItem.DiscountAmount;

            TotalPayAmount += cartItem.PayAmount;
        }
    }
}

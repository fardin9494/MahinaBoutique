using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using DiscountManagement.Infrastracture.EFCore;
using MahinaBoutique.Query.Contract;
using ShopManagement.Application.Contract.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class CartCalculator : ICartCalculator
    {
        private readonly IAuthHelper _authHelper;

        private readonly DiscountContext _discountContext;

        public CartCalculator(IAuthHelper authHelper, DiscountContext discountContext)
        {
            _authHelper = authHelper;
            _discountContext = discountContext;
        }


        public Cart CalculateCart(List<CartItem> cartItems)
        {
            var cart = new Cart();
            var Role = _authHelper.AuthenticatedRole();
            
            if(Role == Roles.ColleagueUser)
            {
                var ColleagueDiscounts = _discountContext.ColleagueDiscounts.Where(x => x.IsActive)
                    .Select(x => new {x.ProductId,x.DiscountRate}).ToList();

                foreach(var item in cartItems)
                {
                   var ColleagueDiscount  = ColleagueDiscounts.FirstOrDefault(x => x.ProductId == item.Id);
                    if(ColleagueDiscount != null)
                    {
                        item.DiscountRate = ColleagueDiscount.DiscountRate;
                        item.DiscountAmount = (item.ItemPrice * item.DiscountRate)/100;
                        item.PayAmount = item.ItemPrice - item.DiscountAmount;
                        cart.Add(item);
                    }
                    else
                    {
                        item.DiscountRate = 0;
                        item.DiscountAmount = 0;
                        item.PayAmount = item.ItemPrice;
                        cart.Add(item);
                    }
                }
            }
            else
            {
                var CustomerDiscounts = _discountContext.CustomerDiscounts.
                    Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now)
                    .Select(x => new {x.ProductId,x.DiscountRate}).ToList();

                foreach(var item in cartItems)
                {
                    var CustomerDiscount = CustomerDiscounts.FirstOrDefault(x => x.ProductId == item.Id);
                    if(CustomerDiscount != null)
                    {
                        item.DiscountRate = CustomerDiscount.DiscountRate;
                        item.DiscountAmount = (item.ItemPrice * item.DiscountRate)/100;
                        item.PayAmount = item.ItemPrice - item.DiscountAmount;
                        cart.Add(item);
                    }
                    else
                    {
                        item.DiscountRate = 0;
                        item.DiscountAmount = 0;
                        item.PayAmount = item.ItemPrice;
                        cart.Add(item);
                    }
                }
            }

            return cart;
        }
    }
}

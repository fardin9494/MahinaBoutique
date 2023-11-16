using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Application.ZarinPal;
using MahinaBoutique.Query.Contract;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        public Cart Carts { get; set; }
        public const string CookieName = "Item-cart";
       
        private readonly ICartCalculator _cartCalculator;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IAuthHelper _authHelper;
        private readonly IZarinPalFactory _zarinPal;
        private readonly IOrderApplication _orderApplication;

        public CheckOutModel(ICartCalculator cartCalculator, ICartService cartService, IProductQuery productQuery, IAuthHelper authHelper, IZarinPalFactory zarinPal, IOrderApplication orderApplication)
        {
            _cartCalculator = cartCalculator;
            _cartService = cartService;
            _productQuery = productQuery;
            _authHelper = authHelper;
            _zarinPal = zarinPal;
            _orderApplication = orderApplication;
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
            _cartService.Set(Carts);
        }

        public IActionResult OnGetPay()
        {
            var cart = _cartService.Get();
            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if(result.Any(x => !x.IsInStock))
            {
              return  RedirectToPage("./Cart");
            }
            var accountId = _authHelper.AuthenticatedAccountId();
            var orderId = _orderApplication.OrderPlace(cart);
            var zarinrequest = _zarinPal.CreatePaymentRequest(cart.TotalPayAmount.ToString(),"","","خرید از سایت",orderId);
            return  Redirect($"https://{_zarinPal.Prefix}.Zarinpal.com/pg/StartPay/{zarinrequest.Authority}");
            
        }

        public RedirectToPageResult OnGetCallBack([FromQuery] long orderId , [FromQuery] string authority, [FromQuery] string status)
        {
            var amount = _orderApplication.GetAmountBy(orderId);
            var verificationResponse = _zarinPal.CreateVerificationRequest(authority,amount.ToString());
            var Result = new PaymentResult();
            if(status == "OK" && verificationResponse.Status == 100)
            {
                 var IssueNo = _orderApplication.Pay(orderId,verificationResponse.RefID);
                 Response.Cookies.Delete(CookieName);
                 Result.Succeeded("پرداخت با موفقیت انجام شد",IssueNo);
                 return RedirectToPage("/PaymentResult",Result);
            }
            else
            {
                Result.Failed("پرداخت ناموفق بود اگر مبلغ از حساب شما کسر شد ظرف 72 ساعت بازمیگردد");
                return RedirectToPage("/PaymentResult",Result);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagment.Infrastracture.Config.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Shop.Order
{
    public class IndexModel : PageModel
    {
       [TempData]
       public string message{get; set;}

        public OrderSearchModel SearchModel { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public List<OrderItemViewModel> Items { get; set; }

        public SelectList Accounts { get; set; }

        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
            
        }


        public void OnGet(OrderSearchModel searchModel)
        {
            Orders = _orderApplication.Search(searchModel);
            Accounts = new SelectList(_accountApplication.GetAccount(),"Id","FullName");
        }

        public RedirectToPageResult OnGetConfirm(long orderId)
        {
            _orderApplication.CallAdmin();
            var res = _orderApplication.Pay(orderId,0);
           if (res == "")
            {
               message = "موجودی انبار به شما اجازه تایید این سفارش را نمیدهد";
            }
            return RedirectToPage("./Index");
            //need check in inventory
        }

        public RedirectToPageResult OnGetCancel(long orderId)
        {
            _orderApplication.Cancel(orderId);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetGetItems(long orderId)
        {
            Items = _orderApplication.Getitems(orderId);
            return Partial("./OrderItem",Items);
        }
    }
}

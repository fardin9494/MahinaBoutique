using _0_SelfBuildFramwork.Application.Sms;
using _0_SelfBuildFramwork.Application;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;
using System.Collections.Generic;
using System.Globalization;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        public static bool CallFromAdmin { get; set; }
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IShopInventoryAcl _shopinventory;
        private readonly IShopAccountAcl _shopAccountAcl;
        private readonly ISmsService _smsService;

        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper, IConfiguration configuration, IShopInventoryAcl shopinventory, IShopAccountAcl shopAccountAcl, ISmsService smsService)
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
            _configuration = configuration;
            _shopinventory = shopinventory;
            _shopAccountAcl = shopAccountAcl;
            _smsService = smsService;

        }

        public void Cancel(long orderId)
        {
            var order = _orderRepository.GetBy(orderId);
            order.Cancel();
            _orderRepository.SaveChanges();
        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
        }

        public void CallAdmin()
        {
            CallFromAdmin = true;
        }

        public long OrderPlace(Cart cart)
        {
            var accountId = _authHelper.AuthenticatedAccountId();
            var order = new Order(accountId,cart.TotalPriceAmount,cart.TotalDiscountAmount,cart.TotalPayAmount);
            foreach(var item in cart.Items)
            {
                var ItemPrice = double.Parse(item.UnitPrice, CultureInfo.CreateSpecificCulture("fa-ir"));
                var orderitem = new Orderitem(item.Id,ItemPrice,item.DiscountRate,item.ProductCount);
                order.Add(orderitem);
            };
            _orderRepository.Create(order);
            _orderRepository.SaveChanges();
            return order.Id;
        }

        public string Pay(long orderId , long refId)
        {
           
           var order = _orderRepository.GetBy(orderId);
           var account = _shopAccountAcl.GetAccountInfo(order.AccountId);
           var symbol = _configuration.GetValue<string>("symbol");
           string IssueNo = CodeGenerator.Generate(symbol);
           order.PaymentSucceeded(refId);
           order.SetIssueTrackingNumber(IssueNo);

            if (CallFromAdmin)
            {
               var items = order.Items;
               int check = 0;
               
                foreach(var item in items)
                {
                   var instock =  _shopinventory.CheckItemInStock(item.ProductId,item.Count);
                    if (!instock)
                    {
                        check += 1;
                    }
                }
                if(check == 0)
                {
                    _shopinventory.ReduceInventory(order.Items);
                    _orderRepository.SaveChanges();
                   _smsService.Send(account.mobile,$"{account.Name} عزیز سفارش شما با کد رهگیری {IssueNo} ثبت شد و ارسال میگردد");
                    return IssueNo;

                    

                }
                
            }
           
            else if (_shopinventory.ReduceInventory(order.Items))
            {   
                _orderRepository.SaveChanges();
                _smsService.Send(account.mobile,$"{account.Name} عزیز سفارش شما با کد رهگیری {IssueNo} ثبت شد ");
                return IssueNo;
            }
            return "";
        }

        public List<OrderViewModel> Search(OrderSearchModel search)
        {
            return _orderRepository.Search(search);
        }

        public List<OrderItemViewModel> Getitems(long orderId)
        {
           return _orderRepository.Getitems(orderId);
        }
    }
}

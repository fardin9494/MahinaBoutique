using _0_SelfBuildFramwork.Application;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;
using System.Globalization;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IShopInventoryAcl _shopinventory;

        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper, IConfiguration configuration, IShopInventoryAcl shopinventory)
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
            _configuration = configuration;
            _shopinventory = shopinventory;
        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
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
           var symbol = _configuration.GetValue<string>("symbol");
           string IssueNo = CodeGenerator.Generate(symbol);
           order.PaymentSucceeded(refId);
           order.SetIssueTrackingNumber(IssueNo);
            if (_shopinventory.ReduceInventory(order.Items))
            {   
                _orderRepository.SaveChanges();
                return IssueNo;
            }
            return "";
        }
    }
}

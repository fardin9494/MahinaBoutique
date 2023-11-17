using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Infrastracture.EfCore;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.InfraStracture.EfCore.Repositories
{
    public class OrderRepository : BaseRepository<long,Order> , IOrderRepository
    {
        private readonly ShopContext _context;
        
        private readonly AccountContext _account;


        public OrderRepository(ShopContext context, AccountContext account):base(context)
        {
            _context = context;
            _account = account;
        }

        public double GetAmountBy(long id)
        {
            return _context.Orders.Select(x => new {x.Id,x.PayAmount}).FirstOrDefault(x => x.Id == id).PayAmount;
        }

        public List<OrderItemViewModel> Getitems(long orderId)
        {
            var Product = _context.Products.Select(x => new {x.Name,x.Id}).ToList();
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            var items = order.Items.Select(x => new OrderItemViewModel{
                Count = x.Count,
                DiscocuntRate = x.DiscocuntRate,
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                }).ToList();

            foreach(var item in items)
            {
                item.Product = Product.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items;
        }

        public List<OrderViewModel> Search(OrderSearchModel search)
        {
            var account = _account.Accounts.Select(x => new {x.Id,x.FullName}).ToList();
            var query = _context.Orders.Select(x => new OrderViewModel{
                AccountId = x.AccountId,
                DiscountAmount = x.DiscountAmount,
                Id = x.Id,
                IsCanceled = x.IsCanceled,
                IsPaid = x.IsPaid,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                RefId = x.RefId,
                TotalPrice = x.TotalPrice,
                CreationDate = x.CreationDate.ToFarsi()
                });

            if(search.AccountId != 0)
            {
                query = query.Where(x => x.AccountId == search.AccountId);
            }

            query = query.Where(x => x.IsCanceled == search.IsCanceled);
           
            var Orders = query.OrderByDescending(x => x.Id).ToList();

            foreach(var order in Orders)
            {
                order.AccountFullName = account.FirstOrDefault(x => x.Id == order.AccountId)?.FullName;
            }

            return Orders;
        }
    }
}

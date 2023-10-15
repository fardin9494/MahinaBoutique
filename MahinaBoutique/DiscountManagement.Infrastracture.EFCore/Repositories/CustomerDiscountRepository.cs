using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastracture.EFCore.Repositories
{
    public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _ShopContext;

        public CustomerDiscountRepository(DiscountContext context,ShopContext shopcontext):base(context)
        {
            _context = context;
            _ShopContext = shopcontext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount{
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                Id = x.Id,
                ProductId = x.ProductId,
                Reason = x.Reason,
                }).FirstOrDefault(x=>x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel search)
        {
            var product = _ShopContext.Products.Select(x => new {x.Id, x.Name}).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel{
                  StartDate = x.StartDate.ToFarsi(),
                  StartDateGlobal =x.StartDate,
                  DiscountRate = x.DiscountRate,
                  EndDate = x.EndDate.ToFarsi(),
                  EndDateGlobal = x.EndDate,
                  Id = x.Id,
                  ProductId = x.ProductId,
                  Reason = x.Reason,

                });

            if(search.ProductId != 0)
            {
                query.Where(x => x.ProductId == search.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(search.StartDate))
            {
                query.Where(x => x.StartDateGlobal >= search.StartDate.ToGeorgianDateTime() );
            }

            if (!string.IsNullOrWhiteSpace(search.EndDate))
            {
                query.Where(x => x.EndDateGlobal <= search.EndDate.ToGeorgianDateTime() );
            }

            var discount = query.OrderByDescending(x => x.Id).ToList();
           
            //foreach (var item in discount)
            //{
            //    item.Product = product.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            //}
            //This foreach like buttom Expression and doing same
            discount.ForEach(x => x.Product = product.FirstOrDefault(y => y.Id == x.ProductId)?.Name);

            return discount;

        }
    }
}

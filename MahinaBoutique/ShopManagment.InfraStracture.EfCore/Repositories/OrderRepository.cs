using _0_SelfBuildFramwork.Infrastracture;
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

        public OrderRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public double GetAmountBy(long id)
        {
            return _context.Orders.Select(x => new {x.Id,x.PayAmount}).FirstOrDefault(x => x.Id == id).PayAmount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public interface IOrderApplication
    {
        long OrderPlace(Cart cart);

        string Pay(long orderId,long refId);

        void Cancel(long orderId);

        double GetAmountBy(long id);

        List<OrderViewModel> Search(OrderSearchModel search);

        public void CallAdmin();

        public List<OrderItemViewModel> Getitems(long orderId);
    }
}

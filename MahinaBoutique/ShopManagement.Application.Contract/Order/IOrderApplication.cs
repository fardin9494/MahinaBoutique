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

        double GetAmountBy(long id);
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class CartItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string UnitPrice { get; set; }

        public int ProductCount { get; set; }

        public double ItemPrice { get; set; }

    }
}

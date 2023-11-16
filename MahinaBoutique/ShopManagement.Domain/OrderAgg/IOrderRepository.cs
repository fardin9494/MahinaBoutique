﻿using _0_SelfBuildFramwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<long,Order>
    {
        double GetAmountBy(long id);
    }
}

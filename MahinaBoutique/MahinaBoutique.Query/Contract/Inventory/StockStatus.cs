﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.Inventory
{
    public class StockStatus
    {
        public bool InStock { get; set; }

        public string Product { get; set; }
    }
}

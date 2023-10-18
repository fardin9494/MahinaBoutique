﻿namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }

        public long productId { get; set; }

        public string Product { get; set; }

        public long CurrentCount { get; set; }

        public double UnitPrice { get; set; }

        public bool InStock { get; set; }
    }
}

using System;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long Id { get; private set; }

        public bool Operation { get; private set; }

        public long Count { get; private set; }

        public DateTime OperationTime { get; private set; }

        public long OperatorId { get; private set; }

        public long CurrentCount { get; private set; }

        public long OrderId { get; private set; }

        public string Description { get; private set; }

        public long InventoryId { get; private set; }

        public Inventory Inventory { get; private set; }

        public InventoryOperation(bool operation, long count, long operatorId, long currentCount, long orderId, string description, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            OrderId = orderId;
            Description = description;
            InventoryId = inventoryId;
            OperationTime = DateTime.Now;
        }
    }
}

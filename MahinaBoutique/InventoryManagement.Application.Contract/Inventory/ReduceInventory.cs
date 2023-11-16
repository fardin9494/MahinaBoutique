namespace InventoryManagement.Application.Contract.Inventory
{
    public class ReduceInventory
    { 
        public long InventoryId {get; set; }

        public long ProductId { get; set; }

        public long OrderId { get; set; }

        public string Description { get; set; }

        public long Count { get; set; }

        public ReduceInventory()
        {

        }

        public ReduceInventory( long productId, long orderId, string description, long count)
        {
            
            ProductId = productId;
            OrderId = orderId;
            Description = description;
            Count = count;
        }
    }
}

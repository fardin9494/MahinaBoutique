using _0_SelfBuildFramwork.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Orderitem : EntityBase
    {
        public long ProductId { get; private set; }

        public long OrderId { get; private set; }

        public double UnitPrice { get; private set; }

        public int DiscocuntRate { get; private set; }

        public int Count { get; private set; }

        public Order Order { get; private set; }

        public Orderitem(long productId, double unitPrice, int discocuntRate, int count)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            DiscocuntRate = discocuntRate;
            Count = count;
        }
    }
}
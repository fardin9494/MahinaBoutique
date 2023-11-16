using _0_SelfBuildFramwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBase
    {
        public long AccountId { get; private set; }

        public double TotalPrice { get; private set; }

        public double DiscountAmount { get; private set; }

        public double PayAmount { get; private set; }

        public string IssueTrackingNo { get; private set; }

        public long RefId { get; private set; }

        public bool IsPaid { get; private set; }

        public bool IsCanceled { get; private set; }

        public List<Orderitem> Items { get; private set; }

        public Order(long accountId, double totalPrice, double discountAmount, double payAmount)
        {
            AccountId = accountId;
            TotalPrice = totalPrice;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            IsPaid = false;
            IsCanceled = false;
            RefId = 0;
            Items = new List<Orderitem>();
        }

        public void Add(Orderitem item)
        {
            Items.Add(item);
        }

        public void PaymentSucceeded(long refId)
        {
            IsPaid = true;
            if(refId != 0)
            {
                RefId = refId;
            }
        }

        public void SetIssueTrackingNumber(string number)
        {
            IssueTrackingNo = number;
        }

        public void Cancel()
        {
            IsCanceled =true;
        }
    }
}

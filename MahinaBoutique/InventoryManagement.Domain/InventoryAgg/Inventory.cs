using _0_SelfBuildFramwork.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }

        public bool InStock { get; private set; }

        public double UnitPrice { get; private set; }

        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var mines = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - mines;
        }

        public void Increase(long Count,long OperatorId,string Description)
        {
            var CurrentCount = CalculateCurrentCount()+Count;
            var operation = new InventoryOperation(true,Count,OperatorId,CurrentCount,0,Description,Id);
            Operations.Add(operation);
            InStock = CurrentCount > 0;
        }

        public void Reduce(long Count,long OperatorId,string Description,long OrderId)
        {
            var CurrentCount = CalculateCurrentCount() - Count;
            var Operation = new InventoryOperation(false,Count,OperatorId,CurrentCount,OrderId,Description,Id);
            Operations.Add(Operation);
            InStock = CurrentCount > 0;
        }
    }
}

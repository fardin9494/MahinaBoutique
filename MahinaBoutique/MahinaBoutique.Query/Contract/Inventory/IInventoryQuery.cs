using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.Inventory
{
    public interface IInventoryQuery
    {
        StockStatus CheckInventoryStatus(IsInStock command);
    }
}

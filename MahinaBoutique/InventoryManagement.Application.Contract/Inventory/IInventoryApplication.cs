using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);

        OperationResult Edit(EditInventory command);

        EditInventory GetDetails(long id);

        List<InventoryViewModel> Search(InventorySearchModel searchModel);

        OperationResult Increase(IncreaseInventory command);

        OperationResult Reduce(ReduceInventory command);

        OperationResult Reduce(List<ReduceInventory> command);
    }
}

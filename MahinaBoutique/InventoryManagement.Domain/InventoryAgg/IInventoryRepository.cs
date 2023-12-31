﻿using _0_SelfBuildFramwork.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    { 
         EditInventory GetDetails(long id);

        List<InventoryViewModel> Search(InventorySearchModel searchModel);

        Inventory GetWith(long ProductId);

        List<InventoryOperationViewModel> Operations (long InventoryId);
        
        bool CheckInventoryStatus(long ProductId , int count);
    }
}

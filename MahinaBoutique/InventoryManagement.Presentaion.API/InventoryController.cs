using InventoryManagement.Application.Contract.Inventory;
using MahinaBoutique.Query.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagement.Presentaion.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IInventoryQuery _inventoryQuery;

        public InventoryController(IInventoryApplication inventoryApplication, IInventoryQuery inventoryQuery)
        {
            _inventoryApplication = inventoryApplication;
            _inventoryQuery = inventoryQuery;
        }


        [HttpGet("{InventoryId}")]
        public List<InventoryOperationViewModel> Operations (long InventoryId)
        {
            return _inventoryApplication.Operations(InventoryId);
        }


        [HttpPost]
       public StockStatus CheckInventoryStatus(IsInStock command)
        {
            return _inventoryQuery.CheckInventoryStatus(command);
        }
    }
}

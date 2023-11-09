using _0_SelfBuildFramwork.Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastracture.Config.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                { "Inventory" , new List<PermissionDto>
                    {
                        new PermissionDto(InventoryPermissions.ListInventory,"ListInventory"),
                        new PermissionDto(InventoryPermissions.SearchInventory,"SearchInventory"),
                        new PermissionDto(InventoryPermissions.EditInventory,"EditInventory"),
                        new PermissionDto(InventoryPermissions.CreateInventory,"CreateInventory"),
                        new PermissionDto(InventoryPermissions.IncreaseInventory,"IncreaseInventory"),
                        new PermissionDto(InventoryPermissions.ReduceInventory,"ReduceInventory"),
                        new PermissionDto(InventoryPermissions.OperationLogInventory,"OperationLogInventory"),

                    }
                }
            };
        }
    }
}

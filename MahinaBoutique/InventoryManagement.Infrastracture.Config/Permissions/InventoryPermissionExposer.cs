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
                        new PermissionDto(30,"ListInventory"),
                        new PermissionDto(31,"SearchInventory"),
                        new PermissionDto(32,"EditInventory"),
                        new PermissionDto(33,"CreateInventory"),

                    }
                }
            };
        }
    }
}

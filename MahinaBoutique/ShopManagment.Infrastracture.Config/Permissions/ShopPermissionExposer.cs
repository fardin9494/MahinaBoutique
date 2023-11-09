using _0_SelfBuildFramwork.Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastracture.Config.Permissions
{
    class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>{
                {"Product", new List<PermissionDto>
                  {
                        new PermissionDto(ShopPermissions.ListProduct,"ListProduct"),
                        new PermissionDto(ShopPermissions.SearchProduct,"SearcProduct"),
                        new PermissionDto(ShopPermissions.EditProduct,"EditProduct"),
                        new PermissionDto(ShopPermissions.CreateProduct,"CreateProduct"),
                        
                  }
                },
                {"ProductCategory",new List<PermissionDto>
                  {
                    new PermissionDto(ShopPermissions.ListProductCategory,"ListProductCategory"),
                    new PermissionDto(ShopPermissions.SearchProductCategory,"SearchProductCategory"),
                    new PermissionDto(ShopPermissions.EditProductCategory,"EditProductCategory"),
                    new PermissionDto(ShopPermissions.CreateProductCategory,"CreateProductCategory"),
                  }
                }
            };
        }
    }
}

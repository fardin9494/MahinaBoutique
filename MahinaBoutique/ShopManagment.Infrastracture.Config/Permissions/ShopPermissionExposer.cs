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
                        new PermissionDto(10,"ListProduct"),
                        new PermissionDto(11,"SearcProduct"),
                        new PermissionDto(12,"EditProduct"),
                        new PermissionDto(13,"CreateProduct"),
                        
                  }
                },
                {"ProductCategory",new List<PermissionDto>
                  {
                    new PermissionDto(20,"ListProductCategory"),
                    new PermissionDto(21,"SearchProductCategory"),
                    new PermissionDto(22,"EditProductCategory"),
                    new PermissionDto(23,"CreateProductCategory"),
                  }
                }
            };
        }
    }
}

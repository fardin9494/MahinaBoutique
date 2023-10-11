using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreatePoductCategory command);

        OperationResult Edit(EditProductCategory ommand);

        EditProductCategory GetDetails(int id);

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);
    }
}

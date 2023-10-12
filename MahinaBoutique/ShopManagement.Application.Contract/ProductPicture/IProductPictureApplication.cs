using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);

        OperationResult Edit(EditProductPicture command);

        EditProductPicture GetDetails(long id);

        OperationResult Remove(long id);

        OperationResult Restore(long id);

        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchmodel);

    }
}

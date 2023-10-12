using _0_SelfBuildFramwork.Domain;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long , ProductPicture>
     {
            List<ProductPictureViewModel> Search(ProductPictureSearchModel searchmodel);

            EditProductPicture GetDetails(long id);

     }
}

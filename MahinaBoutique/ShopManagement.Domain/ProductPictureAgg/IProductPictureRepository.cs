using _0_SelfBuildFramwork.Domain;
using ShopManagement.Application.Contract.ProductPicture;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long , ProductPicture>
     {
            List<ProductPictureViewModel> Search(ProductPictureSearchModel searchmodel);

            EditProductPicture GetDetails(long id);

            ProductPicture GetWithCategory(long id);

     }
}

using _0_SelfBuildFramwork.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.InfraStracture.EfCore.Repositories
{
    public class ProductPictureRepository : BaseRepository<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _shopContext.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchmodel)
        {
            var query = _shopContext.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureViewModel
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                Picture = x.Picture,
                Product = x.Product.Name,
                ProductId = x.ProductId
            });

            if(searchmodel.ProductId != 0)
            {
                query = query.Where(x => x.ProductId == searchmodel.ProductId);
            }

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}

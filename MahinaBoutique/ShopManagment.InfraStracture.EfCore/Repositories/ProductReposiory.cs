using _0_SelfBuildFramwork.Infrastracture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.InfraStracture.EfCore.Repositories
{
    public class ProductReposiory : BaseRepository<long, Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductReposiory(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProduct GetDetails(long id)
        {
            return _shopContext.Products.Select(x => new EditProduct
            {
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Id = x.Id,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _shopContext.Products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Id = x.Id,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Name = x.Name,
                Picture = x.Picture,
                UnitPrice = x.UnitPrice
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                query = query.Where(x => x.Code.Contains(searchModel.Code));
            }
            if(searchModel.CategoryId != 0)
            {
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);
            }

            return query.OrderByDescending(x=> x.Id).ToList();
        }
    }
}

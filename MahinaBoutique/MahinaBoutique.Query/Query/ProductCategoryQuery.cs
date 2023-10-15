using MahinaBoutique.Query.Contract.ProductCategory;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel{
                Id = x.Id,
                Slug = x.Slug,
                Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Name = x.Name,
                }).ToList();
        }
    }
}

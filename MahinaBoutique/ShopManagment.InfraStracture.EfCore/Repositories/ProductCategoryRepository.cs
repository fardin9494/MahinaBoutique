using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Infrastracture;

namespace ShopManagement.InfraStracture.EfCore.Repositories
{
    public class ProductCategoryRepository : BaseRepository<long,ProductCategory> , IProductCategoryRepository
    {
        private readonly ShopContext _dbContext;

        public ProductCategoryRepository(ShopContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public EditProductCategory GetDetails(int id)
        {
            var category = _dbContext.ProductCategories.Select(x => new EditProductCategory
            {
                Description = x.Description,
                Slug = x.Slug,
                Id = x.Id,
                Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
            return category;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
            var query = _dbContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                Image = x.Image,
                Name = x.Name,
                ProductCount = 0
            });

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            return query.OrderByDescending(x => x.Id).ToList();

            
        }
    }
}

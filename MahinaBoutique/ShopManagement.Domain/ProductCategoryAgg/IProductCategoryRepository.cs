using ShopManagement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long,ProductCategory>
    {
        List<ProductCategoryViewModel> GetList();

        EditProductCategory GetDetails(int id);
        
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);
        
    }
}

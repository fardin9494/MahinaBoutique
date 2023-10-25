using _0_SelfBuildFramwork.Domain;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
   public interface IProductRepository : IRepository<long, Product>
    {
        EditProduct GetDetails(long id);

        string GetProductCategorySlug(long productcategoryid);

        Product GetWithCategory(long id);

        List<ProductViewModel> Search(ProductSearchModel searchModel);

        List<ProductViewModel> GetProducts();
    }
}

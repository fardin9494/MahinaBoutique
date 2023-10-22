using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel  GetCategoryWithProductBy(string slug);

        List<ProductCategoryQueryModel> GetCategories();

        List<ProductCategoryQueryModel> GetCategoryWithProducts();
    }
}

using System.Collections.Generic;

namespace MahinaBoutique.Query.Contract.Product
{


    public interface IProductQuery
    {
        List<ProductQueryModel> GetArrivals();

        List<ProductQueryModel> Search(string value);
    }
}

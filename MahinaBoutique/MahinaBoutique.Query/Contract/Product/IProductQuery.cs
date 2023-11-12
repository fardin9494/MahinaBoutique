using ShopManagement.Application.Contract.Order;
using System.Collections.Generic;

namespace MahinaBoutique.Query.Contract.Product
{


    public interface IProductQuery
    {
        List<ProductQueryModel> GetArrivals();

        List<ProductQueryModel> Search(string value);

        ProductQueryModel GetDeatail(string slug);

        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);
    }
}

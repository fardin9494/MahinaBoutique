using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
        public string Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        public long ProductId { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}

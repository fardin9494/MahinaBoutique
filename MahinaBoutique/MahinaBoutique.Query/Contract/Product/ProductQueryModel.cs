using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Picture { get; set; }

        public string PictureTitle { get; set; }

        public string PictureAlt { get; set; }

        public int DiscountRate { get; set; }

        public string Price { get; set; }

        public bool HaveDiscount { get; set; }

        public string PriceAfterDiscount { get; set; }
    }
}

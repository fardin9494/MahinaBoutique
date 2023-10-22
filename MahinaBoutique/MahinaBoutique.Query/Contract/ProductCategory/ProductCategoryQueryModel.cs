using MahinaBoutique.Query.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string ImageAlt { get; set; }

         public string Keyword { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }

        public string ImageTitle { get; set; }

         public string Slug { get; set; }



        public List<ProductQueryModel> Products { get; set; }

    }
}

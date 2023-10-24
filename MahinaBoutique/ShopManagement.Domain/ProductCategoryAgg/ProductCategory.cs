using _0_SelfBuildFramwork.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public string ImageAlt { get; private set; }

        public string ImageTitle { get; private set; }

        public string Keyword { get; private set; }

        public List<Product> Products { get; set; }

        public string MetaDescription { get; private set; }

        public string Slug { get; private set; }


        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, string image, string imageAlt,
            string imageTitle, string keyword, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string description, string image, string imageAlt,
            string imageTitle, string keyword, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrEmpty(image))
            {
                Image = image;
            }
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}

using _0_SelfBuildFramwork.Domain;
using BlogManagement.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }

        public int ShowOrder { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public string ImageTitle { get; private set; }

        public string ImageAlt { get; private set; }

        public string Keywords { get; private set; }

        public string Slug { get; private set; }

        public string MetaDescription { get; private set; }

        public string CanonicalAddress { get; private set; }

        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, int showOrder, string description, string image, string imageTitle, string imageAlt, string keywords, string metaDescription, string canonicalAddress, string slug)
        {
            Name = name;
            ShowOrder = showOrder;
            Description = description;
            Image = image;
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Slug = slug;
        }

        public void Edit(string name, int showOrder, string description, string image, string imageTitle, string imageAlt, string keywords, string metaDescription, string canonicalAddress, string slug)
        {
            Name = name;
            ShowOrder = showOrder;
            Description = description;
            if (!string.IsNullOrWhiteSpace(image))
            {
                Image = image;
            }
            ImageTitle = imageTitle;
            ImageAlt = imageAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Slug = slug;
        }
    }


}

using _0_SelfBuildFramwork.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }

        public string ShortDescription { get; private set; }

        public string Description { get; private set; }

        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public string MetaDescription { get; private set; }

        public string Keywords { get; private set; }

        public string Slug { get; private set; }

        public DateTime PublishDate { get; private set; }

        public string CanonicalAddress { get; private set; }

        public long CategoryId { get; private set; }

        public ArticleCategory Category { get; private set; }

        private Article()
        {

        }

        public Article(string title, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string metaDescription, string keywords,
            string slug, DateTime publishdate, string canonicalAddress, long categoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            PublishDate = publishdate;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }

        public void Edit(string title, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string metaDescription, string keywords,
            string slug, DateTime publishdate, string canonicalAddress, long categoryId)
            {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            PublishDate = publishdate;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            }
    }
}

using MahinaBoutique.Query.Contract.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public string Name { get; set; }

        public int ShowOrder { get; set; }

        public string CreationDate { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string ImageTitle { get; set; }

        public string ImageAlt { get; set; }

        public string Keywords { get; set; }

        public string Slug { get; set; }

        public int ArticleCount { get; set; }

        public string MetaDescription { get; set; }

        public string CanonicalAddress { get; set; }

        public List<string> TagList { get; set; }

        public List<ArticleQueryModel> Articles { get; set; }
    }
}

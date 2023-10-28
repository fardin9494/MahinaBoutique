using BlogManagement.Application.Contract.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Application.Contract.Article
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

    }
}

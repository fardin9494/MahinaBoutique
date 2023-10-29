using MahinaBoutique.Query.Contract.Article;
using MahinaBoutique.Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public List<ArticleCategoryQueryModel> Categories { get; set; }
        public ArticleQueryModel article { get; set; }
        public List<ArticleQueryModel> LatesetArticles { get; set; }
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            article = _articleQuery.GetArticle(id);
            Categories = _articleCategoryQuery.GetArticleCategories();
            LatesetArticles = _articleQuery.LatestArticles();
        }
    }
}

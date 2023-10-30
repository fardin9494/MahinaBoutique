using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahinaBoutique.Query.Contract.Article;
using MahinaBoutique.Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public List<ArticleQueryModel> LatestArticle { get; set; }
        public List<ArticleCategoryQueryModel> Categories { get; set; }
        public ArticleCategoryQueryModel SelectedCategory { get; set; }

        private readonly IArticleCategoryQuery _articleCategory;
        private readonly IArticleQuery _article;

        public ArticleCategoryModel(IArticleCategoryQuery articleCategory, IArticleQuery article)
        {
            _articleCategory = articleCategory;
            _article = article;
        }

        public void OnGet(string id)
        {
            LatestArticle = _article.LatestArticles();
            Categories = _articleCategory.GetArticleCategories();
            SelectedCategory = _articleCategory.SelectArticleCategory(id);
        }
    }
}

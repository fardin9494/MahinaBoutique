using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {

        public ArticleSearchModel SearchModel { get; set; }

        public List<ArticleViewModel> Articles { get; set; }

        public SelectList ArticleCategoris{get; set;}

        private readonly IArticleApplication _article;

        public IndexModel(IArticleApplication article)
        {
            
            _article = article;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            ArticleCategoris = new SelectList(_article.GetArticleCategories(),"Id","Name");
            Articles = _article.Search(searchModel);
        }

        
    }
}

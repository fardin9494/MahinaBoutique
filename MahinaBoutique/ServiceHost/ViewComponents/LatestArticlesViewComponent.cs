using MahinaBoutique.Query.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class LatestArticlesViewComponent : ViewComponent
    {
        public List<ArticleQueryModel> latestArticles { get; set; }
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            latestArticles = _articleQuery.LatestArticles();
            return View("_LatestArticles",latestArticles);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.Article
{
    public interface IArticleQuery
    {
        ArticleQueryModel GetArticle(string Slug);

        List<ArticleQueryModel> LatestArticles();
    }
}

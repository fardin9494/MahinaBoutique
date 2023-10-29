using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> LatestArticles();
    }
}

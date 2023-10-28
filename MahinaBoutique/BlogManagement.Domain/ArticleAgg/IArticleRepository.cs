using _0_SelfBuildFramwork.Domain;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long,Article>
    {
         EditArticle GetDetails(long id);

         string GetSlug(long CategoryId);

        List<ArticleCategoryViewModel> GetArticleCategories();

         List<ArticleViewModel> Search(ArticleSearchModel search);
    }
}

using _0_SelfBuildFramwork.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contract.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);

        OperationResult Edit(EditArticle command);

        EditArticle GetDetails(long id);

        List<ArticleCategoryViewModel> GetArticleCategories();

        List<ArticleViewModel> Search(ArticleSearchModel search);
    }
}

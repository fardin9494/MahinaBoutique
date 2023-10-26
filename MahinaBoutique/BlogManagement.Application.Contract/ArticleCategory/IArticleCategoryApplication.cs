using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);

        OperationResult Edit(EditArticleCategory command);

        EditArticleCategory GetDetail(long id);

        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search);
    }
}

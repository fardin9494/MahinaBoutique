using _0_SelfBuildFramwork.Domain;
using BlogManagement.Application.Contract.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long,ArticleCategory>
    {
        EditArticleCategory GetDetail(long id);

        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search);
    }
}

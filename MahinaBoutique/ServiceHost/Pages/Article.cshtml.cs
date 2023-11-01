using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Article;
using MahinaBoutique.Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public List<ArticleCategoryQueryModel> Categories { get; set; }
        public ArticleQueryModel article { get; set; }
        public CreateComment Command { get; set; }
        public List<ArticleQueryModel> LatesetArticles { get; set; }
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentApplication = commentApplication;
           
        }

        public void OnGet(string id)
        {
            article = _articleQuery.GetArticle(id);
            Categories = _articleCategoryQuery.GetArticleCategories();
            LatesetArticles = _articleQuery.LatestArticles();
        }

        public RedirectToPageResult OnPost(CreateComment command, string slug)
        {
            command.Type = CommentTypesMapping.Article;
            _commentApplication.Create(command);
            return RedirectToPage("./Article",new {id = slug});
        }
    }
}

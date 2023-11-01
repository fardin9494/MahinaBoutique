using _0_SelfBuildFramwork.Application;
using BlogManagement.Infrastracture.EfCore;
using CommentManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Article;
using MahinaBoutique.Query.Contract.Comment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogcontext;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext blogcontext, CommentContext commentContext)
        {
            _blogcontext = blogcontext;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticle(string Slug)
        {
            var article = _blogcontext.Articles.Include(x => x.Category).Select(x => new ArticleQueryModel{
                Id = x.Id,
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                CategorySlug = x.Category.Slug,
                CanonicalAddress = x.CanonicalAddress,
                Category = x.Category.Name,
                Description = x.Description,
                Title = x.Title,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                CategoryId = x.CategoryId,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                }).FirstOrDefault(x => x.Slug == Slug);

            if (!string.IsNullOrWhiteSpace(article.Keywords))
            {
                article.ArticleTags = article.Keywords.Split(",").ToList();
            }
               
            article.Comments = _commentContext.Comments.Where(x => !x.IsCanceled && x.IsConfirmed).
                Where(x => x.Type == CommentTypesMapping.Article).Where(x => x.OwnerRecordId == article.Id).
                Select(x => new CommentQueryModel{
                    Id = x.Id,
                    Massege = x.Message,
                    Name = x.Name,
                    CommentDate = x.CreationDate.ToFarsi(),
                    ParentId = x.ParentId
                    }).OrderBy(x => x.ParentId != 0 ? x.ParentId : x.Id).ThenBy(x => x.Id).ToList();

            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _blogcontext.Articles.Where(x => x.PublishDate >= DateTime.Now).Include(x => x.Category).Select(x => new ArticleQueryModel{
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                CategorySlug = x.Category.Slug,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title,
                PublishDayNumber = x.PublishDate.GetDay(),
                PublishMonth = x.PublishDate.GetMounthName(),
                }).OrderByDescending(x => x.Id).Take(6).ToList();
        }
    }
}

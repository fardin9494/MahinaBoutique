using _0_SelfBuildFramwork.Application;
using BlogManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Article;
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

        public ArticleQuery(BlogContext blogcontext)
        {
            _blogcontext = blogcontext;
        }

        public ArticleQueryModel GetArticle(string Slug)
        {
            var article = _blogcontext.Articles.Include(x => x.Category).Select(x => new ArticleQueryModel{
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
                
            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _blogcontext.Articles.Where(x => x.PublishDate >= DateTime.Now).Include(x => x.Category).Select(x => new ArticleQueryModel{
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
                }).Take(6).ToList();
        }
    }
}

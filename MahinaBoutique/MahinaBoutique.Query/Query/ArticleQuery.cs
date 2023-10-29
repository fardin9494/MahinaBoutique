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

        public List<ArticleQueryModel> LatestArticles()
        {
            return _blogcontext.Articles.Where(x => x.PublishDate >= DateTime.Now).Include(x => x.Category).Select(x => new ArticleQueryModel{
                CanonicalAddress = x.CanonicalAddress,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                CategorySlug = x.Category.Slug,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
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

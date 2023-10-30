using _0_SelfBuildFramwork.Application;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Article;
using MahinaBoutique.Query.Contract.ArticleCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _context.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel{
                Slug = x.Slug,
                ShowOrder = x.ShowOrder,
                ArticleCount = x.Articles.Count(),
                Name = x.Name,
                }).ToList();
        }

        public ArticleCategoryQueryModel SelectArticleCategory(string slug)
        {
            var category = _context.ArticleCategories.Select(x => new ArticleCategoryQueryModel{
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Image = x.Image,
                CreationDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Articles = MapArticles(x.Articles)
                
             }).FirstOrDefault(x => x.Slug == slug);


            if (!string.IsNullOrWhiteSpace(category.Keywords))
            {
                category.TagList = category.Keywords.Split(",").ToList();
            }
            
            return category;
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
           return articles.Select(x => new ArticleQueryModel{
               ShortDescription = x.ShortDescription,
               Slug = x.Slug,
               CanonicalAddress = x.CanonicalAddress,
               Picture = x.Picture,
               PictureAlt = x.PictureAlt,
               PictureTitle = x.PictureTitle,
               PublishDate = x.PublishDate.ToFarsi(),
               Title = x.Title,
               Keywords = x.Keywords,
            
               }).ToList();
        }
    }
}

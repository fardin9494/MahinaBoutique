using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastracture.EfCore.Repositories
{
    public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base (context)
        {
            _context = context;
        }

        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(x => new EditArticle{ 
                CanonicalAddress = x.CanonicalAddress,
                ShortDescription = x.ShortDescription,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Id = x.Id,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title

                }).FirstOrDefault(x => x.Id == id);
        }

        public string GetSlug(long CategoryId)
        {
            return _context.Articles.Include(x => x.Category).FirstOrDefault(x => x.CategoryId == CategoryId).Category.Slug;
        }

        public List<ArticleViewModel> Search(ArticleSearchModel search)
        {
            var query = _context.Articles.Include(x => x.Category).Select(x => new ArticleViewModel{ 
                Category = x.Category.Name,
                ShortDescription = x.ShortDescription,
                CategoryId = x.CategoryId,
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                PublishDate = x.PublishDate.ToFarsi(),
                Picture = x.Picture,
                Title = x.Title
                });

            if (!string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(x => x.Title.Contains(search.Title));
            }
            if(search.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == search.CategoryId);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}

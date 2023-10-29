using BlogManagement.Infrastracture.EfCore;
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
    }
}

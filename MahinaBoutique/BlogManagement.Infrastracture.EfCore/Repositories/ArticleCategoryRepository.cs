using _0_SelfBuildFramwork.Infrastracture;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastracture.EfCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;

        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public EditArticleCategory GetDetail(long id)
        {
            return _context.ArticleCategories.Select(x => new EditArticleCategory{
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Id = x.Id,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name
                }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            var Query = _context.ArticleCategories.Select(x => new ArticleCategoryViewModel{
                ShowOrder = x.ShowOrder,
                Description = x.Description,
                Id = x.Id,
                Image = x.Image,
                Name = x.Name,
                });

            if(search != null)
            {
                Query = Query.Where(x => x.Name == search.Name);
            }

            return Query.OrderByDescending(x => x.ShowOrder).ToList();
        }
    }
}

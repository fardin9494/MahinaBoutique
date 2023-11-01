using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using BlogManagement.Infrastracture.EfCore;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommentManagement.Infrastracture.EfCore.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;
        private readonly BlogContext _blogContext;
        private readonly ShopContext _ShopContext;

        public CommentRepository(CommentContext context, BlogContext blogContext, ShopContext shopContext) : base(context)
        {
            _context = context;
            _blogContext = blogContext;
            _ShopContext = shopContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel search)
        {
            var product = _ShopContext.Products.Select(x => new {x.Id,x.Name }).ToList();
            var article = _blogContext.Articles.Select(x => new {x.Id,x.Title }).ToList();
            var query = _context.Comments.Select(x => new CommentViewModel{
                WebSite = x.WebSite,
                CommentDate = x.CreationDate.ToFarsi(),
                Email =$"{x.Email.Substring(0,Math.Min(x.Email.Length,15))}...",
                FullEmailForSearch = x.Email,
                Id = x.Id,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,
                Message = x.Message,
                Name = x.Name,
                OwnerRecordId = x.OwnerRecordId,
                Type = x.Type,
               
                });

            

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            if (!string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.FullEmailForSearch.Contains(search.Email));
            }

            var Comments = query.OrderByDescending(x => x.Id).ToList();

            foreach(var comment in Comments)
            {
                if(comment.Type == CommentTypesMapping.Article)
                {
                    comment.OwnerName = article.FirstOrDefault(x => x.Id == comment.OwnerRecordId).Title;
                }
                else
                {
                    comment.OwnerName = product.FirstOrDefault(x => x.Id == comment.OwnerRecordId).Name;
                }

            }

            return Comments;
        }

    }
}

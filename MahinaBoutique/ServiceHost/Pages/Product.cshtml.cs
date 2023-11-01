using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product { get; set; }
        public CreateComment Command{get; set;}
        
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetDeatail(id);
        }

        public RedirectToPageResult OnPost(CreateComment command , string slug)
        {
            command.Type = CommentTypesMapping.Product;
            _commentApplication.Create(command);
            return RedirectToPage("/Product",new {id = slug});
        }
    }
}

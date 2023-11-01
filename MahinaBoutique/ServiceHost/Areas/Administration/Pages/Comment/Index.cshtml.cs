using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Comment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments{get; set;}
        public CommentSearchModel SearchModel { get; set; }

        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {
            Comments = _commentApplication.Search(searchModel);
        }

        public RedirectToPageResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }

        public RedirectToPageResult OnPostReject(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./Index");
        }
    }
}

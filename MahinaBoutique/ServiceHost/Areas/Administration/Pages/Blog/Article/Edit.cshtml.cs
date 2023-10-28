using BlogManagement.Application.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class EditModel : PageModel
    {
        public EditArticle Command { get; set; }

        public SelectList Categories{get; set; }

        private readonly IArticleApplication _articleApplication;

        public EditModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }


        public void OnGet(long id)
        {
            Command = _articleApplication.GetDetails(id);
            Categories = new SelectList(_articleApplication.GetArticleCategories(),"Id","Name");
        }

        public RedirectToPageResult OnPost(EditArticle command)
        {
            _articleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}

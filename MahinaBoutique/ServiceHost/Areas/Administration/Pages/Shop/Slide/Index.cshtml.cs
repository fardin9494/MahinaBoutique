using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    { 
        public List<SlideViewModel> Slides { get; set; }

        private readonly ISlideApplication _slidesApplication;

        public IndexModel(ISlideApplication slides)
        {
            _slidesApplication = slides;
        }

        public void OnGet()
        {
            Slides =  _slidesApplication.GetList();
        }

        public IActionResult OnGetCreate()
        { 
            var createSlides= new CreateSlide();
           
            return Partial("./Create",createSlides);
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slidesApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var SelectedItem = _slidesApplication.GetDetails(id);
            return Partial("./Edit",SelectedItem);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slidesApplication.Edit(command);
            return new JsonResult(result);
        }

        public RedirectToPageResult OnGetRemove(long id)
        {
            var result = _slidesApplication.Remove(id);
            return RedirectToPage("./Index");
            //we can control server erorr here with result
        }

        public RedirectToPageResult OnGetRestore(long id)
        {
            var result= _slidesApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}

using MahinaBoutique.Query.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slide;

        public SlideViewComponent(ISlideQuery slide)
        {
            _slide = slide;
        }

        public IViewComponentResult Invoke()
        {
            var query = _slide.GetSlides();
            return View("_Slide",query);
        }
    }
}

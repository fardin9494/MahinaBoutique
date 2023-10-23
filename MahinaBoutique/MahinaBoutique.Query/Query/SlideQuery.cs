using MahinaBoutique.Query.Contract.Slide;
using Microsoft.EntityFrameworkCore;
using ShopManagement.InfraStracture.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace MahinaBoutique.Query.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
           return _context.Slides.Where(x => x.IsDeleted == false).Select(x => new SlideQueryModel{ 
                ButtonText = x.ButtonText,
                Heading = x.Heading,
                Link = x.Link,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title,
                }).AsNoTracking().ToList();
        }
    }
}

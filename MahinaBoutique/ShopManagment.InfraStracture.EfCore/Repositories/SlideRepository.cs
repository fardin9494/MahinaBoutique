using _0_SelfBuildFramwork.Infrastracture;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.InfraStracture.EfCore;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_SelfBuildFramwork.Application;

namespace ShopManagment.InfraStracture.EfCore.Repositories
{
    public class SlideRepository : BaseRepository<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _shopContext;

        public SlideRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditSlide GetDetails(long id)
        {
            return _shopContext.Slides.Select(x => new EditSlide{
                ButtonText = x.ButtonText,
                Heading = x.Heading,
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title,
                Link = x.Link

                }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _shopContext.Slides.Select(x => new SlideViewModel{
                CreationDate = x.CreationDate.ToFarsi(),
                Heading = x.Heading,
                Id = x.Id,
                Picture = x.Picture,
                Title = x.Title,
                IsRemoved = x.IsDeleted,
                }).OrderByDescending(x => x.Id).ToList();
        }
    }
}

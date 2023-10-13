using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);

        OperationResult Edit(EditSlide command);

        EditSlide GetDetails(long id);

        List<SlideViewModel> GetList();

        OperationResult Remove(long id);

        OperationResult Restore(long id);
    }
}

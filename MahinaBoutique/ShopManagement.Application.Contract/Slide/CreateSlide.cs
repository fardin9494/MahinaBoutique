using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Slide
{
    public class CreateSlide
    {
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Picture { get; set; }
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string PictureAlt { get;  set; }
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string PictureTitle { get; set; }
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Heading { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string ButtonText { get; set; }

        public string Link { get; set; }
    }
}

using _0_SelfBuildFramwork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.Slide
{
    public class CreateSlide
    {
        [MaxSizeVallidation(4 * 1024 * 1024,ErrorMessage = ValidationMessages.MaxSizeMessage)]
        [ExtensionValidation(new string[] {".jpeg",".png",".jpg"},ErrorMessage = ValidationMessages.InvalidExtention)]
        public IFormFile Picture { get; set; }
       
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

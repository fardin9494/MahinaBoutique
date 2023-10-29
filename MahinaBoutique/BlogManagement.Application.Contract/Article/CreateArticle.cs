using _0_SelfBuildFramwork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contract.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [ExtensionValidation(new string[] {".jpeg",".jpg",".png"} , ErrorMessage = ValidationMessages.InvalidExtention)]
        [MaxSizeVallidation(4 * 1024 * 1024 , ErrorMessage = ValidationMessages.MaxSizeMessage)]
        public IFormFile Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(199,ErrorMessage = ValidationMessages.MaxCharacterString)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PublishDate { get; set; }

        public string CanonicalAddress { get; set; }

        [Range( 1,long.MaxValue, ErrorMessage =ValidationMessages.Required)]
        public long CategoryId { get; set; }
    }
}

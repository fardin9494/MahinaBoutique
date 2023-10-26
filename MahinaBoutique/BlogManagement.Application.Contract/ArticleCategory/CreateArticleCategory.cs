using _0_SelfBuildFramwork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Name { get; set; }

        [Range(1,1000000,ErrorMessage = ValidationMessages.Required)]
        public int ShowOrder { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Description { get; set; }

        [ExtensionValidation(new string[] {".jpeg",".jpg",".png"},ErrorMessage = ValidationMessages.InvalidExtention)]
        [MaxSizeVallidation(4 * 1024 * 1024,ErrorMessage = ValidationMessages.MaxSizeMessage)]
        public IFormFile Image { get; set; }


        public string ImageTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Slug { get; set; }


        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string MetaDescription { get; set; }

        public string CanonicalAddress { get; set; }
    }
}

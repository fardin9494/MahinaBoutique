using _0_SelfBuildFramwork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
        [MaxSizeVallidation(4 * 1024 * 1024,ErrorMessage = ValidationMessages.MaxSizeMessage)]
        [ExtensionValidation(new string[] {".jpeg",".png",".jpg"},ErrorMessage = ValidationMessages.InvalidExtention)]
        public IFormFile Picture { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string PictureAlt { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string PictureTitle { get; set; }

        [Range(1,10000000,ErrorMessage = ValidationMessages.Required)]
        public long ProductId { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}

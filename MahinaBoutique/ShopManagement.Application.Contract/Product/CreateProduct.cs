﻿using _0_SelfBuildFramwork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Name { get; set; }
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Code { get; set; }


        [MaxSizeVallidation(3 * 1024 * 1024,ErrorMessage = ValidationMessages.MaxSizeMessage)]
        [ExtensionValidation(new string[] {".jpeg",".jpg",".png"}, ErrorMessage = ValidationMessages.InvalidExtention )]
        public IFormFile Picture { get; set; }

        public string PictureTitle { get; set; }

        public string PictureAlt { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string ShortDescription { get; set; }


        public string Description { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string MetaDescription { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Keywords { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Slug { get; set; }

        [Range(1,1000, ErrorMessage =  ValidationMessages.Required)]
        public long CategoryId { get; set; }

        public List<ProductCategoryViewModel> Categories{get; set;}
    }
}

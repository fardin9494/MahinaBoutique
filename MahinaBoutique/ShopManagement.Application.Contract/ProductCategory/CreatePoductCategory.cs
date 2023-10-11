using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreatePoductCategory
    {
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string ImageAlt { get; set; }

        public string ImageTitle { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Keyword { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string MetaDescription { get; set; }
        
        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Slug { get; set; }
    }
}

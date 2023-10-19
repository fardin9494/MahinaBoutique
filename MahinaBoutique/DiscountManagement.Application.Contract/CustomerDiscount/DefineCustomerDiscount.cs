using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }

        [Range(1,101,ErrorMessage=ValidationMessages.Required)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.Required)]
        public string StartDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string EndDate { get; set; }

        public string Reason { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}

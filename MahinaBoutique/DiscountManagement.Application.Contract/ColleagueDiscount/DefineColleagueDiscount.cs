using _0_SelfBuildFramwork.Application;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        public long ProductId { get; set; }

        [Range(1,101,ErrorMessage=ValidationMessages.Required)]
        public int DiscountRate { get; set; }

        public List<ProductViewModel> Products {get; set; }
    }
}

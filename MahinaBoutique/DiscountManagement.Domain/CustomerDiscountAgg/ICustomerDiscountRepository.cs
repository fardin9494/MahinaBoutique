using _0_SelfBuildFramwork.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository:IRepository<long,CustomerDiscount>
    {  
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel search);

        EditCustomerDiscount GetDetails(long id);
    }
}

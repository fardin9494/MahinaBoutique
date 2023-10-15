using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);

        OperationResult Edit(EditCustomerDiscount command);

        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel search);

        EditCustomerDiscount GetDetails(long id);
    }
}

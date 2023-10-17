using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);

        OperationResult Edit(EditColleagueDiscount command);

        OperationResult Active(long id);

        OperationResult Deactive(long id);

        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

        EditColleagueDiscount GetDetails(long id);
    }
}

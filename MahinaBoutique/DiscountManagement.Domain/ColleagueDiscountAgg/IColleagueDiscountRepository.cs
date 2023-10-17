using _0_SelfBuildFramwork.Domain;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository:IRepository<long,ColleagueDiscount>
    {
        
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

        EditColleagueDiscount GetDetails(long id);

    }
}

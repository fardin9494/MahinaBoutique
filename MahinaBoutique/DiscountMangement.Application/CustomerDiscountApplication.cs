using _0_SelfBuildFramwork.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _repository;

        public CustomerDiscountApplication(ICustomerDiscountRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var Operation = new OperationResult();
            if(_repository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
            {
                return Operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var StartDate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();
            var customerdiscount = new CustomerDiscount(command.ProductId,command.DiscountRate,StartDate,EndDate,command.Reason);
            _repository.Create(customerdiscount);
            _repository.SaveChanges();
            return Operation.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var Operation = new OperationResult();
            var cusstomerdiscount = _repository.GetBy(command.Id);
            if(cusstomerdiscount == null)
            {
                return Operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            if(_repository.IsExist(x => x.ProductId == cusstomerdiscount.ProductId && x.DiscountRate == cusstomerdiscount.DiscountRate && x.Id != cusstomerdiscount.Id))
            {
                return Operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var StartDate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();
            cusstomerdiscount.Edit(command.ProductId,command.DiscountRate,StartDate,EndDate,command.Reason);
            _repository.SaveChanges();
            return Operation.Succedded();

        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel search)
        {
            return _repository.Search(search);
        }
    }
}

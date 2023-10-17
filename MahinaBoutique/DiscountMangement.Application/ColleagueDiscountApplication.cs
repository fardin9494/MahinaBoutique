using _0_SelfBuildFramwork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _repository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var selevteddiscount = _repository.GetBy(id);
            if(selevteddiscount == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            selevteddiscount.Active();
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Deactive(long id)
        {
             var operation = new OperationResult();
            var selevteddiscount = _repository.GetBy(id);
            if(selevteddiscount == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            selevteddiscount.Deactive();
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if(_repository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var colleagueDiscount = new ColleagueDiscount(command.ProductId,command.DiscountRate);
            _repository.Create(colleagueDiscount);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var selevteddiscount = _repository.GetBy(command.Id);
            if(selevteddiscount == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
              if(_repository.IsExist(x => x.ProductId == selevteddiscount.ProductId && x.DiscountRate == selevteddiscount.DiscountRate && x.Id != selevteddiscount.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            selevteddiscount.Edit(command.ProductId,command.DiscountRate);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}

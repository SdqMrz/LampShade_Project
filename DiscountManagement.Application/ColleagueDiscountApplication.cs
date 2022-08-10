using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exist(x => x.ProductId == command.ProductId &&
                                                     x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var colleagueDiscount=_colleagueDiscountRepository.Get(command.Id);
            var operation = new OperationResult();

            if(colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.Exist(x => x.ProductId == command.ProductId &&
                            x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Successed();

        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            var operation = new OperationResult();

            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Remove(id);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Restore(long id)
        {
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            var operation = new OperationResult();

            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Restore(id);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Successed();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}

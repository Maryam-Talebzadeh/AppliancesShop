using Base_Framework.Domain.Services;
using DM.Domain.Core.ColleagueDiscountAgg.Data;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.Services.ColleagueDiscountAgg
{
    public class ColleagueDiscountService : IColleagueDiscountService
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountService(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscountDTO command)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            _colleagueDiscountRepository.Create(command);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscountDTO command)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(cd => cd.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.IsExist(cd => cd.ProductId == command.ProductId && cd.DiscountRate == command.DiscountRate && cd.Id != command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            _colleagueDiscountRepository.Edit(command);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public EditColleagueDiscountDTO GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(cd => cd.Id == id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _colleagueDiscountRepository.Remove(id);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(cd => cd.Id == id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _colleagueDiscountRepository.Restore(id);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public List<ColleagueDiscountDTO> Search(SearchColleagueDiscountDTO searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}

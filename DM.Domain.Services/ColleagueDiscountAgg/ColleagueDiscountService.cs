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

        public async Task<OperationResult> Define(DefineColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

           await _colleagueDiscountRepository.Create(command, cancellationToken);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(cd => cd.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.IsExist(cd => cd.ProductId == command.ProductId && cd.DiscountRate == command.DiscountRate && cd.Id != command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            await _colleagueDiscountRepository.Edit(command, cancellationToken);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public async Task<EditColleagueDiscountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(cd => cd.Id == id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _colleagueDiscountRepository.Remove(id, cancellationToken);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Restore(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.IsExist(cd => cd.Id == id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _colleagueDiscountRepository.Restore(id, cancellationToken);
            _colleagueDiscountRepository.Save();

            return operation.Succedded();
        }

        public async Task<List<ColleagueDiscountDTO>> Search(SearchColleagueDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountRepository.Search(searchModel, cancellationToken);
        }
    }
}

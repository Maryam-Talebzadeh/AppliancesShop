using Base_Framework.Domain.Services;
using DM.Domain.Core.CustomerDiscountAgg.Data;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using DM.Domain.Core.CustomerDiscountAgg.Sevices;

namespace DM.Domain.Services.CustomerDiscountAgg
{
    public class CustomerDiscountService : ICustomerDiscountService
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountService(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public async Task<OperationResult> Define(DefineCustomerDiscountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.IsExist(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

           await _customerDiscountRepository.Create(command, cancellationToken);
            _customerDiscountRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditCustomerDiscountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.IsExist(cd => cd.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_customerDiscountRepository.IsExist(cd => cd.ProductId == command.ProductId && cd.DiscountRate == command.DiscountRate && cd.Id != command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            await _customerDiscountRepository.Edit(command, cancellationToken);
            _customerDiscountRepository.Save();

            return operation.Succedded();


        }

        public async Task<EditCustomerDiscountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _customerDiscountRepository.GetDetails(id, cancellationToken);
        }

        public async Task<List<CustomerDiscountDTO>> Search(SearchCustomerDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerDiscountRepository.Search(searchModel, cancellationToken);
        }
    }
}

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

        public global::Base_Framework.Domain.Services.OperationResult Define(DefineCustomerDiscountDTO command)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.IsExist(x => x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            _customerDiscountRepository.Create(command);
            _customerDiscountRepository.Save();

            return operation.Succedded();
        }

        public global::Base_Framework.Domain.Services.OperationResult Edit(EditCustoemrDiscountDTO command)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.IsExist(cd => cd.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_customerDiscountRepository.IsExist(cd => cd.ProductId == command.ProductId && cd.DiscountRate == command.DiscountRate && cd.Id != command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            _customerDiscountRepository.Edit(command);
            _customerDiscountRepository.Save();

            return operation.Succedded();


        }

        public EditCustoemrDiscountDTO GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountDTO> Search(SearchCustomerDiscountDTO searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}

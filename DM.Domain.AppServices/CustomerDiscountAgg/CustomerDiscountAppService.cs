using Base_Framework.Domain.Services;
using DM.Domain.Core.CustomerDiscountAgg.AppSevices;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using DM.Domain.Core.CustomerDiscountAgg.Sevices;
using System.Threading;

namespace DM.Domain.AppServices.CustomerDiscountAgg
{
    public class CustomerDiscountAppService : ICustomerDiscountAppService
    {

        private readonly ICustomerDiscountService _customerDiscountService;

        public CustomerDiscountAppService(ICustomerDiscountService customerDiscountService)
        {
            _customerDiscountService = customerDiscountService;
        }

        public async Task<OperationResult> Define(DefineCustomerDiscountDTO command, CancellationToken cancellationToken)
        {
            return await _customerDiscountService.Define(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditCustomerDiscountDTO command, CancellationToken cancellationToken)
        {
            return await _customerDiscountService.Edit(command, cancellationToken);
        }

        public async Task<EditCustomerDiscountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _customerDiscountService.GetDetails(id, cancellationToken);
        }

        public async Task<List<CustomerDiscountDTO>> Search(SearchCustomerDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            return await _customerDiscountService.Search(searchModel, cancellationToken);
        }
    }
}

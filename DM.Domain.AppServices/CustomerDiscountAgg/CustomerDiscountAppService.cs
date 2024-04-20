using Base_Framework.Domain.Services;
using DM.Domain.Core.CustomerDiscountAgg.AppSevices;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using DM.Domain.Core.CustomerDiscountAgg.Sevices;

namespace DM.Domain.AppServices.CustomerDiscountAgg
{
    public class CustomerDiscountAppService : ICustomerDiscountAppService
    {

        private readonly ICustomerDiscountService _customerDiscountService;

        public CustomerDiscountAppService(ICustomerDiscountService customerDiscountService)
        {
            _customerDiscountService = customerDiscountService;
        }

        public OperationResult Define(DefineColleagueDiscountDTO command)
        {
            return _customerDiscountService.Define(command);
        }

        public OperationResult Edit(EditCustomerDiscountDTO command)
        {
            return _customerDiscountService.Edit(command);
        }

        public EditCustomerDiscountDTO GetDetails(long id)
        {
            return _customerDiscountService.GetDetails(id);
        }

        public List<CustomerDiscountDTO> Search(SearchCustomerDiscountDTO searchModel)
        {
            return _customerDiscountService.Search(searchModel);
        }
    }
}

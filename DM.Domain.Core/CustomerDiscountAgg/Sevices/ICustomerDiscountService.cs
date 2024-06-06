using Base_Framework.Domain.Services;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;

namespace DM.Domain.Core.CustomerDiscountAgg.Sevices
{
    public interface ICustomerDiscountService
    {
        Task<OperationResult> Define(DefineCustomerDiscountDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCustomerDiscountDTO command, CancellationToken cancellationToken);
        Task<EditCustomerDiscountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<CustomerDiscountDTO>> Search(SearchCustomerDiscountDTO searchModel, CancellationToken cancellationToken);
    }
}

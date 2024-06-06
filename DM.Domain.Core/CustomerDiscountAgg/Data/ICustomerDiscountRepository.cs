using Base_Framework.Domain.Core.Contracts;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using DM.Domain.Core.CustomerDiscountAgg.Entities;

namespace DM.Domain.Core.CustomerDiscountAgg.Data
{
    public interface ICustomerDiscountRepository : IRepository<CustomerDiscount>
    {
        Task Create(DefineCustomerDiscountDTO command, CancellationToken cancellationToken);
        Task<EditCustomerDiscountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<CustomerDiscountDTO>> Search(SearchCustomerDiscountDTO searchModel, CancellationToken cancellationToken);
        Task Edit(EditCustomerDiscountDTO command, CancellationToken cancellationToken);
    }
}

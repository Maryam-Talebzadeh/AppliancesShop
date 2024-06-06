using Base_Framework.Domain.Services;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.Core.CustomerDiscountAgg.AppSevices
{
    public interface ICustomerDiscountAppService
    {
        Task<OperationResult> Define(DefineCustomerDiscountDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditCustomerDiscountDTO command, CancellationToken cancellationToken);
        Task<EditCustomerDiscountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<CustomerDiscountDTO>> Search(SearchCustomerDiscountDTO searchModel, CancellationToken cancellationToken);
    }
}

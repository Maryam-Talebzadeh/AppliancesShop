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
        OperationResult Define(DefineCustomerDiscountDTO command);
        OperationResult Edit(EditCustomerDiscountDTO command);
        EditCustomerDiscountDTO GetDetails(long id);
        List<CustomerDiscountDTO> Search(SearchCustomerDiscountDTO searchModel);
    }
}

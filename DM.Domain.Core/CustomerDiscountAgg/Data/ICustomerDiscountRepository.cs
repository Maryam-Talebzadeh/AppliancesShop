using Base_Framework.Domain.Core.Contracts;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;
using DM.Domain.Core.CustomerDiscountAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.Core.CustomerDiscountAgg.Data
{
    public interface ICustomerDiscountRepository : IRepository<CustomerDiscount>
    {
        void Create(DefineCustomerDiscountDTO command);
        EditCustoemrDiscountDTO GetDetails(long id);
        List<CustomerDiscountDTO> Search(SearchCustomerDiscountDTO searchModel);
        void Edit(EditCustoemrDiscountDTO command);
    }
}

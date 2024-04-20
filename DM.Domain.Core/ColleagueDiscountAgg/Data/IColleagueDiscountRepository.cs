using Base_Framework.Domain.Core.Contracts;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Entities;
using DM.Domain.Core.CustomerDiscountAgg.DTOs;

namespace DM.Domain.Core.ColleagueDiscountAgg.Data
{
    public interface IColleagueDiscountRepository : IRepository<ColleagueDiscount>
    {
        void Create(DefineColleagueDiscountDTO command);
        EditCustomerDiscountDTO GetDetails(long id);
        List<CustomerDiscountDTO> Search(SearchColleagueDiscountDTO searchModel);
        void Edit(EditCustomerDiscountDTO command);
        void Remove(long id);
        void Restore(long id);
    }
}

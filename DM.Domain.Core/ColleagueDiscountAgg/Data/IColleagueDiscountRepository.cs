using Base_Framework.Domain.Core.Contracts;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Entities;

namespace DM.Domain.Core.ColleagueDiscountAgg.Data
{
    public interface IColleagueDiscountRepository : IRepository<ColleagueDiscount>
    {
        Task Create(DefineColleagueDiscountDTO command, CancellationToken cancellationToken);
        Task<EditColleagueDiscountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ColleagueDiscountDTO>> Search(SearchColleagueDiscountDTO searchModel, CancellationToken cancellationToken);
        Task Edit(EditColleagueDiscountDTO command, CancellationToken cancellationToken);
        Task Remove(long id, CancellationToken cancellationToken);
        Task Restore(long id, CancellationToken cancellationToken);
    }
}

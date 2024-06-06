
using Base_Framework.Domain.Services;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;

namespace DM.Domain.Core.ColleagueDiscountAgg.AppServices
{
    public interface IColleagueDiscountAppService
    {
        Task<OperationResult> Define(DefineColleagueDiscountDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditColleagueDiscountDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Remove(long id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(long id, CancellationToken cancellationToken);
        Task<EditColleagueDiscountDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ColleagueDiscountDTO>> Search(SearchColleagueDiscountDTO searchModel, CancellationToken cancellationToken);
    }
}

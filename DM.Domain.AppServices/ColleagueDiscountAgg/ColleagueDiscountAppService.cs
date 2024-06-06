using Base_Framework.Domain.Services;
using DM.Domain.Core.ColleagueDiscountAgg.AppServices;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Services;
using DM.Domain.Services.ColleagueDiscountAgg;
using System.Threading;

namespace DM.Domain.AppServices.ColleagueDiscountAgg
{
    public class ColleagueDiscountAppService : IColleagueDiscountAppService
    {
        private readonly IColleagueDiscountService _colleagueDiscountService;

        public ColleagueDiscountAppService(IColleagueDiscountService colleagueDiscountService)
        {
            _colleagueDiscountService = colleagueDiscountService;
        }

        public async Task<OperationResult> Define(DefineColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
           return await _colleagueDiscountService.Define(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditColleagueDiscountDTO command, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountService.Edit(command, cancellationToken);
        }

        public async Task<EditColleagueDiscountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountService.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(long id, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountService.Remove(id, cancellationToken);
        }

        public async Task<OperationResult> Restore(long id, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountService.Restore(id, cancellationToken);
        }

        public async Task<List<ColleagueDiscountDTO>> Search(SearchColleagueDiscountDTO searchModel, CancellationToken cancellationToken)
        {
            return await _colleagueDiscountService.Search(searchModel, cancellationToken);
        }
    }
}

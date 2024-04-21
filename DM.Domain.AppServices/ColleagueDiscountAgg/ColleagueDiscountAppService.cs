using Base_Framework.Domain.Services;
using DM.Domain.Core.ColleagueDiscountAgg.AppServices;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;
using DM.Domain.Core.ColleagueDiscountAgg.Services;
using DM.Domain.Services.ColleagueDiscountAgg;

namespace DM.Domain.AppServices.ColleagueDiscountAgg
{
    public class ColleagueDiscountAppService : IColleagueDiscountAppService
    {
        private readonly IColleagueDiscountService _colleagueDiscountService;

        public ColleagueDiscountAppService(IColleagueDiscountService colleagueDiscountService)
        {
            _colleagueDiscountService = colleagueDiscountService;
        }

        public OperationResult Define(DefineColleagueDiscountDTO command)
        {
           return _colleagueDiscountService.Define(command);
        }

        public OperationResult Edit(EditColleagueDiscountDTO command)
        {
            return _colleagueDiscountService.Edit(command);
        }

        public EditColleagueDiscountDTO GetDetails(long id)
        {
            return _colleagueDiscountService.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            return _colleagueDiscountService.Remove(id);
        }

        public OperationResult Restore(long id)
        {
            return _colleagueDiscountService.Restore(id);
        }

        public List<ColleagueDiscountDTO> Search(SearchColleagueDiscountDTO searchModel)
        {
            return _colleagueDiscountService.Search(searchModel);
        }
    }
}

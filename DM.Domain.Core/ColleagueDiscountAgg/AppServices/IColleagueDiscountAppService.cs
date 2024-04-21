﻿
using Base_Framework.Domain.Services;
using DM.Domain.Core.ColleagueDiscountAgg.DTOs;

namespace DM.Domain.Core.ColleagueDiscountAgg.AppServices
{
    public interface IColleagueDiscountAppService
    {
        OperationResult Define(DefineColleagueDiscountDTO command);
        OperationResult Edit(EditColleagueDiscountDTO command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditColleagueDiscountDTO GetDetails(long id);
        List<ColleagueDiscountDTO> Search(SearchColleagueDiscountDTO searchModel);
    }
}
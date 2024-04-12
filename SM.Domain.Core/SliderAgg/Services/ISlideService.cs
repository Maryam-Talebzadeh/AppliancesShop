using Base_Framework.Domain.Services;
using SM.Domain.Core.SliderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.Services
{
    public interface ISlideService
    {
        OperationResult Create(CreateSlideViewModel command);
        OperationResult Edit(EditSlideViewModel command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        SlideDetailViewModel GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}

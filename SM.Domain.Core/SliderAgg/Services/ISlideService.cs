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
        OperationResult Create(CreateSlideDTO command);
        OperationResult Edit(EditSlideDTO command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlideViewModel GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}

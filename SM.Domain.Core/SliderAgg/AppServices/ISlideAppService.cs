﻿using Base_Framework.Domain.Services;
using SM.Domain.Core.SliderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.AppServices
{
    public interface ISlideAppService 
    {
        OperationResult Create(CreateSlideViewModel command);
        OperationResult Edit(EditSlideViewModel command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlideViewModel GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}

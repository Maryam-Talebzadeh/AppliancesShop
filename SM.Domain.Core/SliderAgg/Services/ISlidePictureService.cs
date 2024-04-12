using Base_Framework.Domain.Services;
using SM.Domain.Core.SliderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.Services
{
    public interface ISlidePictureService
    {
        long Create(CreateSlidePictureDTO command);
        void Edit(EditSlidePictureDTO command);
    }
}

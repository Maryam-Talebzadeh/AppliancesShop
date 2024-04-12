using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.Data
{
    public interface ISlideRepository : IRepository<Slide>
    {
        void Create(CreateSlideDTO slide);
        SlideDTO GetBy(long id);
        void Edit(EditSlideDTO edit);
        SlideDetailDTO GetDetail(long id);
        List<SlideDTO> GetAll();
    }
}

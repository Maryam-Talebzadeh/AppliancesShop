using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Entities;

namespace SM.Domain.Core.SliderAgg.Data
{
    public interface ISlidePictureRepository : IRepository<SlidePicture>
    {
        long Create(CreateSlidePictureDTO create);
        SlidePictureDTO GetBy(long id);
        List<SlidePictureDTO> GetAll();
        void Edit(EditSlidePictureDTO slidePicture);
    }
}

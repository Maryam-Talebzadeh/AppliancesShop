using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;

namespace SM.Domain.Core.ProductCategoryAgg.Data
{
    public interface IPictureRepository : IRepository<long, Picture>
    {
        long Create(CreatePictureDTO create);
        PictureDTO GetBy(long id);
        List<PictureDTO> GetAll();
        void Edit(PictureDTO picture);
    }
}

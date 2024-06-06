using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Entities;

namespace SM.Domain.Core.ProductAgg.Data
{
    public interface IProductPictureRepository : IRepository<ProductPicture>
    {
        Task Create(CreateProductPictureDTO command, CancellationToken cancellationToken);
        Task Edit(EditProductPictureDTO command, CancellationToken cancellationToken);
        Task Remove(long id, CancellationToken cancellationToken);
        Task Restore(long id, CancellationToken cancellationToken);
        Task<DetailProductPictureDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ProductPictureDTO>> Search(SearchProductPictureDTO searchModel, CancellationToken cancellationToken);
        Task<ProductPictureDTO> GetBy(long id, CancellationToken cancellationToken);
    }
}

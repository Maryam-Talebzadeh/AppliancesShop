using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;

namespace SM.Domain.Core.ProductAgg.Services
{
    public interface IProductPictureService
    {
        Task<OperationResult> Create(CreateProductPictureViewModel command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditProductPictureViewModel command, CancellationToken cancellationToken);
        Task<OperationResult> Remove(long id, CancellationToken cancellationToken);
        Task<OperationResult> Restore(long id, CancellationToken cancellationToken);
        Task<DetailProductPictureDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ProductPictureDTO>> Search(SearchProductPictureDTO searchModel, CancellationToken cancellationToken);
    }
}

using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.DTOs.Product;

namespace SM.Domain.Core.ProductAgg.AppSevices
{
    public interface IProductAppService
    {
        Task<OperationResult> Create(CreateProductDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditProductDTO command, CancellationToken cancellationToken);
        Task<ProductDetailDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ProductDTO>> GetProducts(CancellationToken cancellationToken);
        Task<List<ProductDTO>> Search(SearchProductDTO searchModel, CancellationToken cancellationToken);
        Task<OperationResult> NotInStock(long id, CancellationToken cancellationToken);
        Task<OperationResult> IsInStock(long id, CancellationToken cancellationToken);
    }
}

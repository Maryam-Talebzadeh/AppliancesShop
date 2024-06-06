using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.Entities;

namespace SM.Domain.Core.ProductAgg.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<long> Create(CreateProductDTO productCategory, CancellationToken cancellationToken);
        Task<ProductDTO> GetBy(long id, CancellationToken cancellationToken);
        Task Edit(EditProductDTO edit, CancellationToken cancellationToken);
        Task<ProductDetailDTO> GetDetail(long id, CancellationToken cancellationToken);
        Task<List<ProductDTO>> Search(SearchProductDTO searchModel, CancellationToken cancellationToken);
        Task<List<ProductDTO>> GetAll( CancellationToken cancellationToken);
        Task NotInStock(long id, CancellationToken cancellationToken);
        Task IsInStock(long id, CancellationToken cancellationToken);
        Task<string> GetCategorySlugByProductId(long id, CancellationToken cancellationToken);
    }
}

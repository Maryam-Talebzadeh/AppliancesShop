using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.Services;

namespace SM.Domain.AppServices.ProductAgg
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<OperationResult> Create(CreateProductDTO command, CancellationToken cancellationToken)
        {
            return await _productService.Create(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditProductDTO command, CancellationToken cancellationToken)
        {
            return await _productService.Edit(command, cancellationToken);
        }

        public async Task<ProductDetailDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _productService.GetDetails(id, cancellationToken);
        }

        public async Task<List<ProductDTO>> GetProducts(CancellationToken cancellationToken)
        {
            return await _productService.GetProducts(cancellationToken);
        }

        public async Task<OperationResult> IsInStock(long id, CancellationToken cancellationToken)
        {
           return await _productService.IsInStock(id, cancellationToken);
        }

        public async Task<OperationResult> NotInStock(long id, CancellationToken cancellationToken)
        {
           return await _productService.NotInStock(id, cancellationToken);
        }

        public async Task<List<ProductDTO>> Search(SearchProductDTO searchModel, CancellationToken cancellationToken)
        {
            return await _productService.Search(searchModel, cancellationToken);
        }
    }
}

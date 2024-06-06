using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Services;

namespace SM.Domain.AppServices.ProductAgg
{
    public class ProductPictureAppService : IProductPictureAppService
    {
        private readonly IProductPictureService _productPictureService;

        public ProductPictureAppService(IProductPictureService productPictureService)
        {
            _productPictureService = productPictureService;
        }

        public async Task<OperationResult> Create(CreateProductPictureViewModel command, CancellationToken cancellationToken)
        {
            return await _productPictureService.Create(command, cancellationToken);
        }

        public async Task<OperationResult> Edit(EditProductPictureViewModel command, CancellationToken cancellationToken)
        {
            return await _productPictureService.Edit(command, cancellationToken);
        }

        public async Task<DetailProductPictureDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _productPictureService.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(long id, CancellationToken cancellationToken)
        {
            return await _productPictureService.Remove(id, cancellationToken);

        }

        public async Task<OperationResult> Restore(long id, CancellationToken cancellationToken)
        {
            return await _productPictureService.Restore(id, cancellationToken);
        }

        public  async Task<List<ProductPictureDTO>> Search(SearchProductPictureDTO searchModel, CancellationToken cancellationToken)
        {
            return await _productPictureService.Search(searchModel, cancellationToken);
        }
    }
}

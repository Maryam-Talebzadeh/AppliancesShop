using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Services;
using System.Threading;

namespace SM.Domain.Services.ProductAgg
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductService(IProductRepository productRepository, IProductPictureRepository productPictureRepository)
        {
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
        }

        public async Task<OperationResult> Create(CreateProductDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            if (_productRepository.IsExist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            command.Slug = command.Slug.Slugify();

            long productId = await _productRepository.Create(command, cancellationToken);
            var categorySlug = await _productRepository.GetCategorySlugByProductId(productId, cancellationToken);

            #region Save First picture

            string picName = "";

            if (command.Picture != null)
            {
                picName = "DefaultProduct.jpg";
            }

            picName = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductPictures", picName);
            FileHandler.SaveImage(path, command.Picture);

            #endregion

            var productPictureDTO = new CreateProductPictureDTO()
            {
                PictureTitle = command.PictureTitle,
                PictureAlt = command.PictureAlt,
                Picture = picName,
                ProductId = productId
            };

          await  _productPictureRepository.Create(productPictureDTO, cancellationToken);
            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditProductDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var product = await _productRepository.GetBy(command.Id, cancellationToken);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
           await _productRepository.Edit(command, cancellationToken);
            _productRepository.Save();

            return operation.Succedded();
        }

        public async Task<ProductDetailDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _productRepository.GetDetail(id, cancellationToken);
        }

        public async Task<List<ProductDTO>> GetProducts(CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll(cancellationToken);
        }

        public async Task<OperationResult> IsInStock(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var product = await _productRepository.GetBy(id, cancellationToken);

            if (product == null)
                return  operation.Failed(ApplicationMessages.RecordNotFound);

           await _productRepository.IsInStock(id, cancellationToken);
            _productRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> NotInStock(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var product = await _productRepository.GetBy(id, cancellationToken);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _productRepository.NotInStock(id, cancellationToken);
            _productRepository.Save();
            return operation.Succedded();
        }

        public async Task<List<ProductDTO>> Search(SearchProductDTO searchModel, CancellationToken cancellationToken)
        {
            return await _productRepository.Search(searchModel, cancellationToken);
        }
    }
}

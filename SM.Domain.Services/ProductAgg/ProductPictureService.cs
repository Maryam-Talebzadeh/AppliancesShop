using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Services;

namespace SM.Domain.Services.ProductAgg
{
    public class ProductPictureService : IProductPictureService
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;

        public ProductPictureService(IProductPictureRepository productPictureRepository, IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
        }

        public async Task<OperationResult> Create(CreateProductPictureViewModel command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_productPictureRepository.IsExist(p => p.PictureTitle == command.PictureTitle && p.ProductId == command.ProductId))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var category = await _productRepository.GetBy(command.ProductId, cancellationToken);
            long categoryId = category.CategoryId;
            var categorySlug = await _productRepository.GetCategorySlugByProductId(command.ProductId, cancellationToken);

            #region Save picture

            string picName = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", command.ProductId.ToString(), "ProductPictures", picName);
            FileHandler.SaveImage(path, command.Picture);

            #endregion

            var picture = new CreateProductPictureDTO()
            {
                ProductId = command.ProductId,
                Picture = picName,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle
            };

            await _productPictureRepository.Create(picture, cancellationToken);
            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditProductPictureViewModel command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var picture = await _productPictureRepository.GetBy(command.Id, cancellationToken);

            if (picture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",command.ProductId.ToString(), "ProductPictures");

                #region Delete Old Image

                if (picture.Picture != "DefaultProduct.jpg")
                {
                    FileHandler.DeleteFile(Path.Combine(path, picture.Picture));
                }

                #endregion

                #region Save picture

                picture.Picture = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                path = Path.Combine(path, picture.Picture);
                FileHandler.SaveImage(path, command.Picture);

                #endregion

            }

            var pictureDTO = new EditProductPictureDTO()
            {
                Id = command.Id,
                Picture = picture.Picture,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle,
                ProductId = command.ProductId
            };

            await _productPictureRepository.Edit(pictureDTO, cancellationToken);
            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public async Task<DetailProductPictureDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _productPictureRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Remove(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var picture = await _productPictureRepository.GetBy(id, cancellationToken);

            if (picture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _productPictureRepository.Remove(id,cancellationToken);
            _productPictureRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> Restore(long id, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var picture = await _productPictureRepository.GetBy(id, cancellationToken);

            if (picture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            await _productPictureRepository.Restore(id, cancellationToken);
            _productPictureRepository.Save();
            return operation.Succedded();
        }


        public async Task<List<ProductPictureDTO>> Search(SearchProductPictureDTO searchModel, CancellationToken cancellationToken)
        {
            return await _productPictureRepository.Search(searchModel, cancellationToken);
        }
    }

}
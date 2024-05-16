using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Services;

namespace SM.Domain.Services.ProductAgg
{
    public class ProductPictureService : IProductPictureService
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureService(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPictureViewModel command)
        {
            var operation = new OperationResult();

            if (_productPictureRepository.IsExist(p => p.PictureTitle == command.PictureTitle && p.ProductId == command.ProductId))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            #region Save picture

            string picName = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductPictures", picName);
            FileHandler.SaveImage(path, command.Picture);

            #endregion

            var picture = new CreateProductPictureDTO()
            {
                ProductId = command.ProductId,
                Picture = picName,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle
            };

            _productPictureRepository.Create(picture);
            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPictureViewModel command)
        {
            var operation = new OperationResult();
            var picture = _productPictureRepository.GetBy(command.Id);

            if (picture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductPictures");

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

            _productPictureRepository.Edit(pictureDTO);
            _productPictureRepository.Save();

            return operation.Succedded();
        }

        public DetailProductPictureDTO GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var picture = _productPictureRepository.GetBy(id);

            if (picture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _productPictureRepository.Remove(id);
            _productPictureRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var picture = _productPictureRepository.GetBy(id);

            if (picture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _productPictureRepository.Restore(id);
            _productPictureRepository.Save();
            return operation.Succedded();
        }


        public List<ProductPictureDTO> Search(SearchProductPictureDTO searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }

}
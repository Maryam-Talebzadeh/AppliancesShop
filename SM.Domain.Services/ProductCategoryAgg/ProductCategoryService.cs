using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using SM.Domain.Core.ProductCategoryAgg.Services;

namespace SM.Domain.Services.ProductCategoryAgg
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IPictureRepository _pictureRepository;


        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IPictureRepository pictureRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _pictureRepository = pictureRepository;
        }
        public OperationResult Create(CreateProductCategoryViewModel command)
        {
            var operation = new OperationResult();

            if (_productCategoryRepository.IsExist(pc => pc.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            command.Slug = GenerateSlug.Slugify(command.Slug);
            string picName = "Appliances.jpg";

            if (command.Picture != null)
            {
                #region Save picture

                picName = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AdminTheme", "ProductCategoryPictures", picName);
                FileHandler.SaveImage(path, command.Picture);

                #endregion
            }

            var picture = new CreatePictureDTO()
            {
                Name = picName,
                Title = command.PictureTitle,
                Alt = command.PictureAlt

            };

            var picId = _pictureRepository.Create(picture);

            var productCategory = new CreateProductCategoryDTO()
            {
                Name = command.Name,
                Description = command.Description,
                MetaDescription = command.MetaDescription,
                KeyWords = command.Keywords,
                Slug = command.Slug,
                PictureId = picId
            };

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategoryViewModel command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.GetBy(command.Id);

            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productCategoryRepository.IsExist(pc => pc.Name == command.Name && pc.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            command.Slug = GenerateSlug.Slugify(command.Slug);

            if (command.Picture != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AdminTheme", "ProductCategoryPictures");

                #region Delete Old Image

                if (command.PictureName != "Appliances.jpg")
                {
                    FileHandler.DeleteFile(Path.Combine(path, command.PictureName));
                }

                #endregion

                #region Save picture

                command.PictureName = NameGenarator.GenerateUniqeCode() + Path.GetExtension(command.Picture.FileName);
                path = Path.Combine(path, command.PictureName);
                FileHandler.SaveImage(path, command.Picture);

                #endregion
            }

            var picture = new PictureDTO()
            {
                Id = productCategory.PictureId,
                Name = command.PictureName,
                Title = command.PictureTitle,
                Alt = command.PictureAlt

            };

            _pictureRepository.Edit(picture);
            _pictureRepository.Save();

            var productCategoryDTO = new EditProductCategoryDTO()
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                MetaDescription = command.MetaDescription,
                KeyWords = command.Keywords,
                Slug = command.Slug,
                PictureId = productCategory.PictureId
            };

            _productCategoryRepository.Edit(productCategoryDTO);
            _productCategoryRepository.Save();

            return operation.Succedded();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.GetAll().Select(p =>
            new ProductCategoryViewModel()

            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                ProductsCount = p.ProductsCount,
                Picture = _pictureRepository.GetBy(p.PictureId).Name
            }).ToList();
        }

        public ProductCategoryDetailViewModel GetDetail(long id)
        {
            var productCategory = _productCategoryRepository.GetDetail(id);
            var picture = _pictureRepository.GetBy(productCategory.PictureId);


            return new ProductCategoryDetailViewModel()
            {
                Id = productCategory.Id,
                Name = productCategory.Name,
                Description = productCategory.Description,
                Keywords = productCategory.KeyWords,
                MetaDescription = productCategory.MetaDescription,
                Slug = productCategory.Slug,
                PictureTitle = picture.Title,
                PictureAlt = picture.Alt,
                PictureName = picture.Name
            };
        }

        public List<ProductCategoryViewModel> Search(SearchProductCategoryDTO searchModel)
        {
            return _productCategoryRepository.Search(searchModel).Select(p =>
             new ProductCategoryViewModel()

             {
                 Id = p.Id,
                 Name = p.Name,
                 CreationDate = p.CreationDate,
                 ProductsCount = p.ProductsCount,
                 Picture = _pictureRepository.GetBy(p.PictureId).Name
             }).ToList();
        }
    }
}

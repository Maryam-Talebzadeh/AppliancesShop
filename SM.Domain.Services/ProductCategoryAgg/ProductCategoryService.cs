using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Services.ProductCategoryAgg
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public OperationResult Create(CreateProductCategoryDTO command)
        {
            var operation = new OperationResult();

            if (_productCategoryRepository.IsExist(pc => pc.Name == command.Name))
                return operation.Failed("نام وارد شده تکراری است.. لطفا یک نام دیگه امتحان کن.");

            command.Slug = GenerateSlug.Slugify(command.Slug);
            _productCategoryRepository.Create(command);
            _productCategoryRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategoryDTO command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.GetBy(command.Id);

            if (productCategory == null)
                return operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد. لطفا دوباره امتحان کن.");

            if (_productCategoryRepository.IsExist(pc => pc.Name == command.Name && pc.Id != command.Id))
                return operation.Failed("نام وارد شده تکراری است.. لطفا یک نام دیگه امتحان کن.");

            command.Slug = GenerateSlug.Slugify(command.Slug);
            _productCategoryRepository.Edit(command);
            _productCategoryRepository.Save();

            return operation.Succedded();
        }

        public ProductCategoryDetailDTO GetDetail(long id)
        {
            return _productCategoryRepository.GetDetail(id);
        }

        public List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}

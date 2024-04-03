using ServiceFramework;
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
            throw new NotImplementedException();
        }

        public ProductCategoryDetailDTO GetDetail(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel)
        {
            throw new NotImplementedException();
        }
    }
}

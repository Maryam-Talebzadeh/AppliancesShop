using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Domain.Core.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SM.Domain.Services.ProductAgg
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductDTO command)
        {
            var operation = new OperationResult();
            if (_productRepository.IsExist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            _productRepository.Create(command);
            _productRepository.Save();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductDTO command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            _productRepository.Edit(command);
            _productRepository.Save();

            return operation.Succedded();
        }

        public ProductDetailDTO GetDetails(long id)
        {
            return _productRepository.GetDetail(id);
        }

        public List<ProductDTO> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public OperationResult IsInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _productRepository.IsInStock(id);
            _productRepository.Save();
            return operation.Succedded();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            _productRepository.NotInStock(id);
            _productRepository.Save();
            return operation.Succedded();
        }

        public List<ProductDTO> Search(SearchProductDTO searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}

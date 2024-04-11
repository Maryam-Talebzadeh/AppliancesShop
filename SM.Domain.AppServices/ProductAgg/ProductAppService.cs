using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SM.Domain.AppServices.ProductAgg
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }

        public OperationResult Create(CreateProductDTO command)
        {
           return _productService.Create(command);
        }

        public OperationResult Edit(EditProductDTO command)
        {
            return _productService.Edit(command);
        }

        public ProductDetailDTO GetDetails(long id)
        {
            return _productService.GetDetails(id);
        }

        public List<ProductDTO> GetProducts()
        {
            return _productService.GetProducts();
        }

        public OperationResult IsInStock(long id)
        {
           return _productService.IsInStock(id);
        }

        public OperationResult NotInStock(long id)
        {
           return _productService.NotInStock(id);
        }

        public List<ProductDTO> Search(SearchProductDTO searchModel)
        {
            return _productService.Search(searchModel);
        }
    }
}

using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.AppServices.ProductAgg
{
    public class ProductPictureAppService : IProductPictureAppService
    {
        private readonly IProductPictureService _productPictureService;

        public ProductPictureAppService(IProductPictureService productPictureService)
        {
            _productPictureService = productPictureService;
        }

        public OperationResult Create(CreateProductPictureViewModel command)
        {
            return _productPictureService.Create(command);
        }

        public OperationResult Edit(EditProductPictureViewModel command)
        {
            return _productPictureService.Edit(command);
        }

        public DetailProductPictureDTO GetDetails(long id)
        {
            return _productPictureService.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            return _productPictureService.Remove(id);

        }

        public OperationResult Restore(long id)
        {
            return _productPictureService.Restore(id);
        }

        public List<ProductPictureDTO> Search(SearchProductPictureDTO searchModel)
        {
            return _productPictureService.Search(searchModel);
        }
    }
}

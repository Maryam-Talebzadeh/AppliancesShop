using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Domain.Core.ProductCategoryAgg.AppServices;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Services;

namespace SM.Domain.AppServices.ProductCategoryAgg
{
    public class ProductCategoryAppService : IProductCategoryAppService
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryAppService(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public global::Base_Framework.Domain.Services.OperationResult Create(CreateProductCategoryDTO command)
        {
            return _productCategoryService.Create(command);
        }

        public global::Base_Framework.Domain.Services.OperationResult Edit(EditProductCategoryDTO command)
        {
            return (_productCategoryService.Edit(command));
        }

        public ProductCategoryDetailDTO GetDetail(long id)
        {
            return _productCategoryService.GetDetail(id);
        }

        public List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel)
        {
            return _productCategoryService.Search(searchModel);
        }
    }
}

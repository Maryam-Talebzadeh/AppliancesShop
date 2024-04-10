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

        public global::Base_Framework.Domain.Services.OperationResult Create(CreateProductCategoryViewModel command)
        {
            return _productCategoryService.Create(command);
        }

        public global::Base_Framework.Domain.Services.OperationResult Edit(EditProductCategoryViewModel command)
        {
            return (_productCategoryService.Edit(command));
        }

        public List<ProductCategoryViewModel> GetAll()
        {
           return _productCategoryService.GetAll();
        }

        public ProductCategoryDetailViewModel GetDetail(long id)
        {
            return _productCategoryService.GetDetail(id);
        }

        public List<ProductCategoryViewModel> Search(SearchProductCategoryDTO searchModel)
        {
            return _productCategoryService.Search(searchModel);
        }
    }
}

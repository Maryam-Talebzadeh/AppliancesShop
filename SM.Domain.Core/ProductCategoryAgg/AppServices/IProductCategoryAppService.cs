using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.AppServices
{
    public interface IProductCategoryAppService
    {
        OperationResult Create(CreateProductCategoryViewModel command);
        OperationResult Edit(EditProductCategoryViewModel command);
        List<ProductCategoryViewModel> Search(SearchProductCategoryDTO searchModel);
        ProductCategoryDetailViewModel GetDetail(long id);
        public List<ProductCategoryViewModel> GetAll();
    }
}

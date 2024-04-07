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
        OperationResult Create(CreateProductCategoryDTO command);
        OperationResult Edit(EditProductCategoryDTO command);
        List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel);
        ProductCategoryDetailDTO GetDetail(long id);
    }
}

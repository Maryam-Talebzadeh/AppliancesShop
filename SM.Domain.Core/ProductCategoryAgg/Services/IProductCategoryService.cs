using SM.Domain.Core.ProductCategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.Services
{
    public interface IProductCategoryService
    {
        void Create(CreateProductCategoryDTO command);
        void Edit(EditProductCategoryDTO command);
        List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel);
        ProductCategoryDetailDTO GetDetail(int id);
    }
}

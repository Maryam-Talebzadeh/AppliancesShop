using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.Services
{
    public interface IProductService
    {
        OperationResult Create(CreateProductDTO command);
        OperationResult Edit(EditProductDTO command);
        EditProductDTO GetDetails(long id);
        List<ProductDTO> GetProducts();
        List<ProductDTO> Search(SearchProductDTO searchModel);
    }
}

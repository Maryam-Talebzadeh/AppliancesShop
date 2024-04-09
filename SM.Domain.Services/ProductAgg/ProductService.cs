using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.DTOs;
using SM.Domain.Core.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Services.ProductAgg
{
    public class ProductService : IProductService
    {
        public OperationResult Create(CreateProductDTO command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditProductDTO command)
        {
            throw new NotImplementedException();
        }

        public EditProductDTO GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> Search(SearchProductDTO searchModel)
        {
            throw new NotImplementedException();
        }
    }
}

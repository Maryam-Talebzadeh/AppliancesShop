using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.Data
{
    public interface IProductRepository : IRepository<long, Product>
    {
        void Create(CreateProductDTO productCategory);
        ProductDTO GetBy(long id);
        void Edit(EditProductDTO edit);
        ProductDetailDTO GetDetail(long id);
        List<ProductDTO> Search(SearchProductDTO searchModel);
        List<ProductDTO> GetAll();
        void NotInStock(long id);
        void IsInStock(long id);
    }
}

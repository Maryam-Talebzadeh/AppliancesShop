using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using SM.Domain.Core.ProductAgg.Entities;

namespace SM.Domain.Core.ProductAgg.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        long Create(CreateProductDTO productCategory);
        ProductDTO GetBy(long id);
        void Edit(EditProductDTO edit);
        ProductDetailDTO GetDetail(long id);
        List<ProductDTO> Search(SearchProductDTO searchModel);
        List<ProductDTO> GetAll();
        void NotInStock(long id);
        void IsInStock(long id);
        string GetCategorySlugByProductId(long id);
    }
}

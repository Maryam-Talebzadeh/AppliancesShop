

namespace SM.Domain.Core.ProductAgg.DTOs.Product
{
    public class EditProductDTO : CreateProductDTO
    {
        public long Id { get; set; }
        public string CategorySlug { get; set; }
    }
}

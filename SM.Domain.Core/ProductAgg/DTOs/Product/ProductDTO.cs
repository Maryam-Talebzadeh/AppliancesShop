

namespace SM.Domain.Core.ProductAgg.DTOs.Product
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public string CategorySlug { get; set; }
        public string CreationDate { get; set; }
        public bool IsInStock { get; set; }
    }
}

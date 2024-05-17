

namespace SM.Domain.Core.ProductAgg.DTOs.ProductPicture
{
    public class ProductPictureDTO
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductId { get; set; }
        public bool IsRemoved { get; set; }
        public string CategorySlug { get; set; }
    }
}

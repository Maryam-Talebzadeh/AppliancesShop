using Base_Framework.Domain.Core;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace IM.Domain.Core.InventoryAgg.DTOs
{
    public class CreateInventoryDTO
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}

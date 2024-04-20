using Base_Framework.Domain.Core;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace DM.Domain.Core.CustomerDiscountAgg.DTOs
{
    public class DefineCustomerDiscountDTO
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }

        public string Reason { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}

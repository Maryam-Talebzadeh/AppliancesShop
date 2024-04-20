using Base_Framework.Domain.Core;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.Core.ColleagueDiscountAgg.DTOs
{
    public class DefineColleagueDiscountDTO
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}

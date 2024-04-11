using SM.Domain.Core.ProductAgg.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.DTOs.ProductPicture
{
    public class DetailProductPictureDTO : EditProductPictureDTO
    {
        public List<ProductDTO> Products { get; set; }
    }
}

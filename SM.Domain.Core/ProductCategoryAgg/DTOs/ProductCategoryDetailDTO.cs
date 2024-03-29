using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.DTOs
{
    public class ProductCategoryDetailDTO : EditProductCategoryDTO
    {
        public bool IsDeleted { get; set; }
    }
}

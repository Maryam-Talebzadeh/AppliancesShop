using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.DTOs
{
    public class CreateProductCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
    }
}

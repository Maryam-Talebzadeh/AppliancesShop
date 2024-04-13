using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.DTOs
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Picture { get; set; }
        public long ProductsCount { get; set; }
        public string Slug { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}

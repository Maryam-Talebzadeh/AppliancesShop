using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.DTOs
{
    public class PictureDTO
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Title { get;  set; }
        public string Alt { get; set; }
    }
}

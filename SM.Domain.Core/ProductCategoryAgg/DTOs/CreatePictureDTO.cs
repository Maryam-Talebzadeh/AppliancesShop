using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.DTOs
{
    public class CreatePictureDTO
    {
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }
    }
}

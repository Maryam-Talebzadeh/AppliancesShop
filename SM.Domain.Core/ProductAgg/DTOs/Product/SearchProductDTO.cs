using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.DTOs.Product
{
    public class SearchProductDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long CategoryId { get; set; }
    }
}

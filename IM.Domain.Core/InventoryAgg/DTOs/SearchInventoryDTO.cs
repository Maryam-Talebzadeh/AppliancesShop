using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Domain.Core.InventoryAgg.DTOs
{
    public class SearchInventoryDTO
    {
        public long ProductId { get; set; }
        public bool InStock { get; set; }
    }
}

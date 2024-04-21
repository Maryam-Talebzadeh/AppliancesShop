using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Domain.Core.InventoryAgg.DTOs
{
    public class EditInventoryDTO : CreateInventoryDTO
    {
        public long Id { get; set; }
    }
}

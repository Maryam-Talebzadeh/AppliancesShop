﻿

namespace IM.Domain.Core.InventoryAgg.DTOs
{
    public class ReduceInventoryDTO
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}

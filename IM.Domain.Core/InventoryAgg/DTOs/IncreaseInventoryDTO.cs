

namespace IM.Domain.Core.InventoryAgg.DTOs
{
    public class IncreaseInventoryDTO
    {
        public long InventoryId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
    }
}

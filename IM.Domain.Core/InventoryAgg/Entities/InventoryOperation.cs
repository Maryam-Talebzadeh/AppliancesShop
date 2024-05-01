using Base_Framework.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Domain.Core.InventoryAgg.Entities
{
    public class InventoryOperation : BaseEntity
    {
        public bool Operation { get; private set; }  //if 1 then Increase, if 0 then Decrease
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }
        protected InventoryOperation() { }

        public InventoryOperation(bool operation, long count, long operatorId, long currentCount,
            string description, long orderId, long invetoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = invetoryId;
            OperationDate = DateTime.Now;
        }
    }
}

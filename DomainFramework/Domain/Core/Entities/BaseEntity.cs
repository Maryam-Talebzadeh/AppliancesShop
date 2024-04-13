using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Framework.Domain.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsRemoved = false;
            CreationDate = DateTime.Now;
        }

        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void ReStore()
        {
            IsRemoved = false;
        }
    }
}

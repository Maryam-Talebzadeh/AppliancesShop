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
            IsDeleted = false;
        }

        public long Id { get; set; }
        public bool IsDeleted { get; set; }

        void Remove()
        {
            IsDeleted = true;
        }

        void ReStore()
        {
            IsDeleted = false;
        }
    }
}
